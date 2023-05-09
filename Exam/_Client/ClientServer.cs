using MessageDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client
{
    // Класс который отвечает за связь между клиентом и сервером
    internal class ClientServer
    {
        public TcpClient client { get; set; }/*
         * TcpClient класс, представляющий клиентское подключение TCP. 
         * Он используется для установления соединения с сервером и передачи 
         * данных между клиентом и сервером.
         */
        ViewController view;/*
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
        public ClientServer()
        {
            view = new ViewController();
            formatter = new BinaryFormatter();
        }
        public void Start()
        {
            string res = view.ShowConnectDialog();
            if (res != null)
            {
                try
                {
                    string[] str = res.Split('|');
                    // IP NickName
                    message = new MyMessage();
                    message._user = str[0];
                    Connect(str[1]);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void ShowMainMenu()
        {
            string temp = view.ShowMainMenuDialog();
            if (temp == "NEW_GAME")
            {
                // показать окно с запросом новой игры
                string Name = view.ShowNameGameDialog();
                if (Name != null)
                {
                    SendMessage("[CREATE_GROUP]", Name);
                }
                else
                {
                    // Показываем главное меню
                    ShowMainMenu();
                }
            }
            // присоединится
            else if (temp == "[LIST_GROUP]")
            {
                SendMessage(temp,null);
            }
            else if (temp == "EXIT")
            {
                // выход
                client.Close();
            }
        }
        private void Connect(string IP)
        {
            client = new TcpClient();
            // IP - Порт(совпадает с сервером)
            client.Connect(IP, 49152); // 192.168.0.102
            netstream = client.GetStream();
        }
        public async void ReadMessage()
        {
            await Task.Run(() =>
            {
                try
                {
                    // Создаем объект BinaryFormatter для десериализации данных
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Получаем поток NetworkStream для чтения данных
                    netstream = client.GetStream();
                    MyMessage rec = new MyMessage();
                    // чтобы он не вышел
                    while (true)
                    {
                        if (netstream.DataAvailable)
                        {
                            rec = (MyMessage)formatter.Deserialize(netstream);
                        if (rec._code == "[GROUP_CREATED]")
                        {
                            view.ShowAdminLobby(message._user);
                        }
                        else if (rec._code == "[LIST_GROUP]")
                        {
                            List<string> names = rec._message.Split('|').ToList();
                            ShowListGroup(names);
                        }
                        // мы присоединились
                        else if (rec._code == "[CONNECTED]")
                        {
                            List<string> players = rec._message.Split('|').ToList();
                            Parallel.Invoke(() => { 
                                ShowStartGame(players); });
                            SendMessage("[CONNECTED]", null);
                        }
                        else if (rec._code == "[CONNECTED_TO_GROUP]")
                        {
                            // message содержит имя учасника, который присоединился
                            view.AddPlayerToStartGameModel(message._message);
                        }
                        else
                        {
                            MessageBox.Show("ошибка чтения");
                        }
                        }
                        else
                        {
                            Task.Delay(1000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    client.Close();
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        private void ShowListGroup(List<string> games)
        {
            string res = view.ShowListGames(games);
            if (res != null)
            {
                SendMessage("[CONNECT]", res);
            }
        }
        private async void ShowStartGame(List<string> players)
        {
            await Task.Run(() =>
            {
                view.ShowStartGameModel(players);
            });
        }
        private async void SendMessage(string _code,string _message)
        {
            try
            {
                if (client.Connected)
                {
                    message._code = _code;
                    message._message = _message;
                    formatter.Serialize(netstream, message);
                    await netstream.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
