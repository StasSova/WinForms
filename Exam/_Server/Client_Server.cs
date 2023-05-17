using _Server.FolderGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using MessageDll;
using System.Threading;
using System.Drawing;

namespace _Server
{
    // Controller
    // служит для связи
    internal class Client_Server
    {
        private int PORT = 8080;
        View view;
        private ListGroup _group;
        SynchronizationContext uiContext;
        public Client_Server(View view) 
        { 
            _group = new ListGroup(); 
            uiContext = SynchronizationContext.Current;
            this.view = view;
        }
        public async void StartServer()
        {
            await Task.Run(() =>
            {
                try
                {
                    // TcpListener ожидает подключения от TCP-клиентов сети.
                    TcpListener listener = new TcpListener(
                    IPAddress.Any /* Предоставляет IP-адрес, указывающий, что сервер должен контролировать действия 
                                   * клиентов на всех сетевых интерфейсах.*/,
                    PORT /* порт */);
                    listener.Start(); // Запускаем ожидание входящих запросов на подключение
                    view.AddToListBox("Сервер запущен");
                    while (true)
                    {
                        // Принимаем ожидающий запрос на подключение 
                        // Метод AcceptTcpClient — это блокирующий метод, возвращающий объект TcpClient, 
                        // который может использоваться для приема и передачи данных.
                        TcpClient client = listener.AcceptTcpClient();
                        ReadMessage(client);
                    }
                }
                catch (Exception ex)
                {
                    view.AddToListBox(ex.Message);
                }
            });
        }
        private async void ReadMessage(TcpClient client)
        {
            await Task.Run(async () =>
            {
                Player player = null;
                try
                {
                    // сообщения, которые мы будем отправлять клиенту
                    MyMessage message = new MyMessage();
                    message._user = "SERVER";       // имя пользователя 
                                                    //message._code = "[LOAD]";  // код сообщения
                                                    //message._message = "привет";  // сообщение
                    // Создаем объект BinaryFormatter для десериализации данных
                    BinaryFormatter formatter = new BinaryFormatter();

                    // Получаем поток NetworkStream для чтения данных
                    /*
                        NetworkStream - это поток для чтения и записи данных через сетевое соединение.
                    В частности, NetworkStream предоставляет методы для чтения и записи байтов в поток, 
                    а также для чтения и записи структур и объектов с помощью BinaryReader и BinaryWriter
                    */
                    NetworkStream netstream = client.GetStream();
                    Group group = null;

                    // Читаем данные из потока и десериализуем объект Message
                    while (true)
                    {
                        if (netstream.DataAvailable)
                        {
                            try
                            {
                                MyMessage received = (MyMessage)formatter.Deserialize(netstream);
                                // Обработка полученного сообщения
                                view.AddToListBox($"{received._code}\t{received._user}\t{received._message}");
                                if (player == null) player = new Player(client, received._user);
                                // Клиент нажал на кнопку новая игра 
                                if (received._code == "[CREATE_GROUP]")
                                {
                                    // received._message - содержит название группы
                                    _group.CreateGroup(received._message, player);
                                    group = _group.GetGroup(player);
                                    message._code = "[GROUP_CREATED]";
                                    message._message = player._nickname;
                                    SendMessageToClient(client, message);
                                }
                                // Клиент нажал на кнопку присоединится к игре
                                else if (received._code == "[LIST_GROUP]")
                                {
                                    // мы должны отправить список игр клиенту
                                    message._code = "[LIST_GROUP]";
                                    message._message = string.Join("|", _group.GetAllGroupName());
                                    SendMessageToClient(client, message);
                                }
                                // Клиент выбрал игру, к которой необходимо присоединится
                                else if (received._code == "[CONNECT]")
                                {
                                    // received._message  - содержит название игры к которой
                                    // необходимо присоединить клиента

                                    Task addPlayerTask = new Task(() =>
                                    {
                                        _group.AddPlayerToGroup(received._message, player);
                                    });
                                    addPlayerTask.Start();
                                    Task.WaitAll(addPlayerTask);

                                    // отправляем ему код об присоединении
                                    message._code = "[CONNECTED]";
                                    group = _group.GetGroup(player);
                                    // так же список игроков, которые там есть
                                    List<string> players = group.GetPlayersNameWithout(player);
                                    players.Add(player._nickname);
                                    message._message = string.Join("|", players);
                                    SendMessageToClient(client, message);
                                }
                                else if (received._code == "[CONNECTED]")
                                {
                                    // а всем остальным отправляем сообщение о том, что к ним присоединились
                                    message._code = "[CONNECTED_TO_GROUP]";
                                    message._message = player._nickname;    // кто присоединился
                                    List<Player> players = group.GetPlayersWithout(player);
                                    if (players != null)
                                    {
                                        Parallel.ForEach<Player>(players, i =>
                                        { SendMessageToClient(i._tcp, message); });
                                    }
                                }
                                // Выход учасника из лобби
                                else if (received._code == "[EXITFROMGAME]")
                                {
                                    message._code = "[REMOVE]";
                                    message._message = player._nickname;
                                    foreach (Player p in group.GetPlayersWithout(player))
                                    {
                                        SendMessageToClient(p._tcp, message);
                                    }
                                    group.RemoveFromGroup(player);
                                }
                                // Выход админа из лобби
                                else if (received._code == "[REMOVEGAME]")
                                {
                                    message._code = "[EXIT]";
                                    foreach (Player p in group.GetPlayersWithout(player))
                                    {
                                        SendMessageToClient(p._tcp, message);
                                    }
                                    _group.RemoveGroup(group);
                                }
                                // Клиент выходит из игры
                                else if (received._code == "[EXIT]")
                                {
                                    _group.RemovePlayerFromGroup(player);
                                    group = null;
                                }
                                else if (received._code == "[EXITALL]")
                                {
                                    _group.RemovePlayerFromGroup(player);
                                    break;
                                }
                                else if (received._code == "[START_GAME]")
                                {   // это сообщения отправляет лидер группы
                                    // достаем группу, в которой есть этот учасник
                                    Task GetGroup = new Task(() =>
                                    {
                                        group = _group.GetGroup(player);
                                    });
                                    GetGroup.Start();
                                    Task.WaitAll(GetGroup);

                                    group.InGame = true;     // меняем статус игры
                                    // получаем учасников игры, без лидера группы
                                    List<Player> players = group.GetPlayersWithout(player);
                                    players.Add(player);
                                    message._code = "[START_GAME]";
                                    message._message = null;
                                    foreach (var item in players)
                                    {
                                        // каждому отправляем сообщение о начале игры
                                        SendMessageToClient(item._tcp, message);
                                    }
                                }
                                else if (received._code == "[ImREADY]")
                                {
                                    // Отправляется когда игрок написал начало своей истории

                                    // Создаем начало истории для конкретного учасника
                                    player.history.themes.Add(received._message);

                                    // увеличиваем число игроков, готовых к следующему раунду
                                    group.CurrrentNumberReadyPlayers++;  
                                    // Если все готовы запускаем второй раунд,
                                    // где учасники должны нарисовать то что прочли
                                    if (group.CurrrentNumberReadyPlayers ==
                                    group.MaxNumberReadyPlayers)
                                    {
                                        group.CurrrentNumberReadyPlayers = 0;
                                        group.CurrentRound++;
                                        message._code = "[DRAW]";
                                        foreach (var item in group._players)
                                        {
                                            // получаю историю следующего игрока, после данного
                                            History temp = group.NextPlayer(item).history;
                                            // после этого в сообщения автора, я записываю, кому принадлежала история
                                            // после получания картинки, я смогу идентифицировать автора данной истории
                                            // так же передаем то, что он загадал
                                            message._message = string.Join("|", temp.author, temp.themes.Last());
                                           SendMessageToClient(item._tcp, message);
                                        }
                                    }
                                }
                                else if (received._code == "[DRAW]")
                                {
                                    // Получаем рисунок.
                                    group.CurrrentNumberReadyPlayers++;
                                    // в сообщении содержится имя, владельца истории
                                    // ему добавляем теперь картирнку
                                    received._bitmap.Tag = received._color;
                                    group._players.Find(p => p._nickname == received._message).history.images.Add(received._bitmap);
                                    // если все готовы, начинаем отправку сообщений
                                    if (group.CurrrentNumberReadyPlayers == group.MaxNumberReadyPlayers)
                                    {
                                        // если кол-во раундов == количеству учасников, игра завершается
                                        // показываем историю игры
                                        if (group.CurrentRound >= group.MaxNumberReadyPlayers)
                                        {
                                            // отправка сообщений клиенту о том что игра оконченна
                                            // Клиент открывает форму, которая читаем дальнейшие изображения
                                            // и добавляет истории
                                            message._code = "[ENDGAME]";
                                            message._bitmap = null;
                                            message._message = null;
                                            foreach (var item in group._players)
                                            {
                                                SendMessageToClient(item._tcp, message);
                                            }
                                            // для того, чтобы форма успела открытся
                                            await Task.Delay(1000);
                                            message._code = "[HISTORY]";
                                            // для каждого игрока
                                            foreach (var item in group._players)
                                            {
                                                // история данного игрока
                                                for (int i = 0; i < item.history.themes.Count; i++)
                                                {
                                                    // ник автора истории и тема его истории
                                                    message._message = string.Join("|", item._nickname, item.history.themes[i]);
                                                    // изображение истории
                                                    message._bitmap = item.history.images[i];
                                                    message._color = (Color)message._bitmap.Tag;
                                                    // пол секунды задрежки с исопльзованием Task.Delay
                                                    // который в отличие от обычного Thread.Sleep не
                                                    // блокирует поток в котором был вызван метод, 
                                                    // а ещё и освобождает ресуры, занимаемые процессором,
                                                    // для других опериций.
                                                    await Task.Delay(500);
                                                    // Отправка всем игрокам
                                                    foreach (var item2 in group._players)
                                                    {
                                                        SendMessageToClient(item2._tcp, message);
                                                    }
                                                }
                                                item.history = new History(item._nickname);
                                                await Task.Delay(1000);
                                            }
                                            await Task.Delay(2000);
                                            message._message = null;
                                            message._bitmap = null;
                                            message._code = "[ENDHISTORY]";
                                            foreach (var item in group._players)
                                            {
                                                SendMessageToClient(item._tcp, message);
                                            }
                                            _group.RemoveGroup(group);
                                        }  
                                        else
                                        {
                                            Random r = new Random();
                                            group.CurrentRound++;
                                            group.CurrrentNumberReadyPlayers = 0;
                                            message._code = "[THEME]";
                                            List<History> history = new List<History>();
                                            foreach (var item in group._players)
                                            {
                                                // заполняем массив историй 
                                                history.Add(item.history); 
                                            }
                                            foreach (var item in group._players)
                                            {
                                                // находим случайный номер истории
                                                int pos = r.Next(0, history.Count-1);
                                                message._message = history[pos].author;
                                                message._bitmap = history[pos].images.Last();
                                                message._color = (Color)history[pos].images.Last().Tag;
                                                SendMessageToClient(item._tcp, message);
                                                history.Remove(history[pos]);
                                            }
                                        }
                                    }
                                }
                                else if (received._code == "[THEME]")
                                {
                                    // получаем историю, которую прочли с рисунка
                                    group.CurrrentNumberReadyPlayers++;

                                    // в первой части имя автора истории
                                    // во второй описание
                                    string[] mes = received._message.Split('|');
                                    group._players.Find(p => p._nickname == mes[0]).history.themes.Add(mes[1]);

                                    if (group.CurrrentNumberReadyPlayers == group.MaxNumberReadyPlayers)
                                    {
                                        group.CurrrentNumberReadyPlayers = 0;
                                        message._code = "[DRAW]";
                                        foreach (var item in group._players)
                                        {
                                            // получаю историю следующего игрока, после данного
                                            History temp = group.NextPlayer(item).history;
                                            // после этого в сообщения автора, я записываю, кому принадлежала история
                                            // после получания картинки, я смогу идентифицировать автора данной истории
                                            // так же передаем то, что он загадал
                                            message._message = string.Join("|", temp.author, temp.themes.Last());
                                            SendMessageToClient(item._tcp, message);
                                        }
                                    }
                                }
                                else if (received._code == "[RESETGROUP]")
                                {
                                    if (group!= null)
                                    {
                                        group.RemoveFromGroup(player);
                                        group= null;
                                    }
                                }
                            }
                            catch (Exception e) 
                            { 
                                //view.AddToListBox(e.Message); 
                            }
                        }
                        else
                        {
                            await Task.Delay(1000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //view.AddToListBox(ex.Message); 
                    //client.Close();
                    _group.RemovePlayerFromGroup(player);
                }
            });
        }
        // Создаем объект BinaryFormatter для сериализации данных
        BinaryFormatter formatter = new BinaryFormatter();
        public async void SendMessageToClient(TcpClient client, MyMessage message)
        {
            try
            {
                // Получаем поток NetworkStream для записи данных
                NetworkStream netstream = client.GetStream();
                // Сериализуем сообщение и отправляем его клиенту
                formatter.Serialize(netstream, message);
                // ожидаем завершение асинхронной операции без блокирования
                // основного потока. После завершение метода, продолжится выполнения
                // метода, который вызвал await 
                await netstream.FlushAsync();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                view.AddToListBox(ex.Message);
            }
        }

    }
}
