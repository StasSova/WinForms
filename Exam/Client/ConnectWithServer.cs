using MessageDll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal class ConnectWithServer
    {
        private int PORT = 8080;
        private static ConnectWithServer instance;
        public TcpClient client { get; set; }/*
         * TcpClient класс, представляющий клиентское подключение TCP. 
         * Он используется для установления соединения с сервером и передачи 
         * данных между клиентом и сервером.
         */
        View view;/*
         *  ViewController класс, служащий для управления отображением 
         *  графического интерфейса пользователя (GUI). Обычно этот класс 
         *  содержит методы и свойства для обновления содержимого окон, 
         *  управления видимостью элементов управления и прочего.
         */
        MyMessage message;/*
         *  Message класс, представляющий сообщение, которое может быть отправлено 
         *  или принято с сервера. Этот класс может содержать информацию, такую как 
         *  имя пользователя, код сообщения и текст сообщения.
         */
        NetworkStream netstream;/*
         * NetworkStream - класс, представляющий поток данных между клиентом 
         * и сервером. Он используется для чтения и записи данных в сеть.
         */
        BinaryFormatter formatter; /*
         * BinaryFormatter - класс, предназначенный для сериализации и 
         * десериализации объектов в бинарном формате. Он используется для 
         * передачи объектов между клиентом и сервером.
        */
        bool isRead = true;
        private ConnectWithServer()
        {
            view = new View();
            formatter = new BinaryFormatter();
        }
        ~ConnectWithServer()
        {
            client?.Close();
            netstream?.Close();
            isRead = false;
        }
        public static ConnectWithServer GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnectWithServer();
            }
            return instance;
        }
        public Task Start()
        {
            try
            {
                // возвращается результат 
                string res = view.ConnectToServer();
                // разбиваем на 2 составные
                // Ник - IP
                string[] str = res.Split('|');
                message = new MyMessage();  // инициализация сообщений для отправки серверу
                message._user = str[0];     // Кто отправляет
                // Попытка присоединения
                Connect(str[1]);
                // Показываем главное меню
                Menu();
            }
            catch { isRead = false; }
            return Task.CompletedTask;
        }
        private void Connect(string IP)
        {
            client = new TcpClient();
            // IP - Порт(совпадает с сервером)
            client.Connect(IP, PORT); // 192.168.0.102
            netstream = client.GetStream();
        }
        private void Menu()
        {
            string res = view.Menu();
            // присоединится к игре. 
            // Отправка запроса серверу на присоединение к игре
            if (res == "[LIST_GROUP]")
            {
                message._code = "[LIST_GROUP]";
                message._message = null;
                message._bitmap = null;
                SendMessage();
            }
            // если мы вышли из подмодели (Ввод названия игры или при выборе игры)
            else if (res == "[CANCEL]")
            {
                Menu();
            }
            // Хранится название игры, которую мы хотим создать
            else if (res.StartsWith("*"))
            {
                message._code = "[CREATE_GROUP]"; // говорим серверу что мы хотим создать игру
                message._message = res.Substring(1); // с таким названием
                SendMessage();
            }
            // Выход генерируется через throw
        }
        public Task ReadMessage()
        {
            if (client.Connected && isRead)
                try
                {
                    // Создаем объект BinaryFormatter для десериализации данных
                    BinaryFormatter formatter = new BinaryFormatter();
                    // для полученных сообщений
                    MyMessage rec = new MyMessage();
                    while (isRead)
                    {
                        // если поток занят, делаем задержку чтения
                        if (netstream.DataAvailable)
                        {
                            // читаем сообщения
                            rec = (MyMessage)formatter.Deserialize(netstream);
                            // Сообщение о том что группа созданна или мы присоединились
                            if (rec._code == "[GROUP_CREATED]" || rec._code == "[CONNECTED]")
                            {
                                // отправка учасникам, о том что мы присоединились
                                if (rec._code == "[CONNECTED]")
                                {
                                    message._code = "[CONNECTED]";
                                    message._message = null;
                                    message._bitmap = null;
                                    SendMessage();
                                }
                                string res = view.Lobby(client,rec._message);
                                // 4 исхода событий. 
                                // или мы удаляем игру (крестик или удалить игру) (админ)
                                if (res == "[REMOVE]")
                                {
                                    message._code = "[REMOVEGAME]";
                                    message._message = null;
                                    message._bitmap = null;
                                    SendMessage();
                                    Menu();
                                }
                                // или мы выходим из игры
                                else if (res == "[EXIT]")
                                {
                                    message._code = "[EXITFROMGAME]";
                                    message._message = null;
                                    message._bitmap = null;
                                    SendMessage();
                                    Menu();
                                }
                                // или игра была удалена
                                else if (res == "[MENU]")
                                {
                                    Menu();
                                }
                                // или мы ее запускаем
                                else if (res == "[START]")
                                {
                                    // ПЕРВАЯ ИГРА
                                    string theme = view.FirstGame();
                                    if (theme == "[EXIT]")
                                    {
                                        // удаляем с команд
                                        message._code = "[EXIT]";
                                        message._message = null;
                                        message._bitmap = null;
                                        SendMessage();
                                        Menu();
                                    }
                                    else
                                    {
                                        message._code = "[ImREADY]";
                                        message._message = theme;
                                        message._bitmap = null;
                                        SendMessage();
                                    }

                                }
                            }

                            else if (rec._code == "[LIST_GROUP]")
                            {
                                string name = view.ListGame(rec._message);
                                // 2 исхода
                                // 1й - мы не выбрали игру
                                if (name == "[CANCEL]")
                                {
                                    Menu();
                                }
                                // 2й - мы выбрали игру
                                else
                                {
                                    message._code = "[CONNECT]";
                                    message._message = name;
                                    message._bitmap = null;
                                    SendMessage();
                                }
                            }
                            // получаем команду на рисование 
                            else if (rec._code == "[DRAW]")
                            {
                                string[] mes = rec._message.Split('|');
                                // в первом хранится имя автора истории
                                // во втором что рисовать
                                Bitmap btm = view.Draw(mes[1]);
                                // вышли или ещё что-то, удаляем из игры
                                if (btm == null) 
                                {
                                    message._code = "[EXIT]";
                                    message._message = null;
                                    message._bitmap = null;
                                    SendMessage();
                                    Menu();
                                }
                                else
                                {
                                    message._code = "[DRAW]";
                                    message._message = mes[0]; // имя владельца истории
                                    message._bitmap = btm;
                                    message._color = (Color)btm.Tag;
                                    SendMessage();
                                }
                            }
                            else if (rec._code == "[THEME]")
                            {
                                // я получаю в rec._message автора истории
                                // в rec._bitmap - картинка, которую нужно описать
                                rec._bitmap.Tag = rec._color;
                                string result = view.ShowPictureDescription(rec._bitmap);
                                if (result != null)
                                {
                                    message._code = "[THEME]";
                                    message._message = string.Join("|", rec._message, result);
                                    message._bitmap = null;
                                    SendMessage();
                                }
                                else
                                {
                                    message._code = "[EXIT]";
                                    message._message = null;
                                    message._bitmap = null;
                                    SendMessage();
                                    Menu();
                                }
                            }
                            // получение истории игры
                            else if (rec._code == "[ENDGAME]")
                            {
                                view.History(client);
                                message._code = "[RESETGROUP]";
                                message._message = null;
                                message._bitmap = null;
                                SendMessage();
                                Menu();
                            }
                            else
                            {
                                MessageBox.Show("ошибка чтения");
                            }
                        }
                        else
                        {
                            Task.Delay(1000); /*
                         *      Простыми словами это тоже самое что и Thread.Sleep(1000).
                         * Отличие заключается в том что данный метод не блокирует поток, 
                         * на котором он вызывается, а просто возвращает задачу, которая 
                         * завершится через указанный интервал времени. 
                         *      Это означает, что во время ожидания Task.Delay другие задачи 
                         * могут выполняться,а поток, на котором он вызывается, 
                         * может быть переиспользован для выполнения другой работы.
                         */
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Отправляем серверу сообщение о том, что мы выходим
                    message._code = "[EXITALL]"; // полный выход
                    message._message = null;
                    message._bitmap = null;
                    SendMessage();
                    // прекращаем чтение потока
                    isRead = false;
                    // указываем ошибку
                    if (ex.Message != "[EXIT]")
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            // завершаем задачу
            return Task.CompletedTask;
        }
        private async void SendMessage()
        {
            if (client.Connected)
            {
                formatter.Serialize(netstream, message);
                await netstream.FlushAsync();
            }
        }
    }
}
