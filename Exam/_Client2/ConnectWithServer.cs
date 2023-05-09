using MessageDll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client2
{
    internal class ConnectWithServer
    {
        private int PORT = 8080;
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
        bool isRead = true;
        public ConnectWithServer()
        {
            view = new ViewController();
            formatter = new BinaryFormatter();
        }
        ~ConnectWithServer()
        {
            isRead= false;
        }
        public Task Start()
        {
            string res = view.ShowConnect();
            if (res != null)
            {
                try
                {
                    string[] str = res.Split('|');
                    message = new MyMessage();
                    message._user = str[0];
                    message._bitmap = null;
                    Connect(str[1]);
                    // Показываем главное меню
                    res = view.ShowMenu();
                    if (res == null)
                    {
                        throw new Exception("Внеплановое закрытие");
                    }
                    // если нажал на присоединится
                    else if(res == "[LIST_GROUP]")
                    {
                        message._code = res; // отправляем запрос что нам нужен весь список игр
                        message._message = null; // сообщения нету
                    }
                    // если не присоединится значит там будет название игры, которую мы создадим 
                    else if (res != "[LIST_GROUP]") 
                    {
                        message._code = "[CREATE_GROUP]"; // говорим серверу что мы хотим создать игру
                        message._message = res; // с таким названием
                    }
                    else
                    {
                        throw new Exception("Внеплановое закрытие");
                    }
                    SendMessage();
                }
                catch (Exception ex)
                {
                    netstream?.Close();
                    client?.Close();
                    MessageBox.Show(ex.Message);
                }
                return Task.CompletedTask;
            }
            else
            {
                throw new Exception("Пока");
            }
        }
        private void Connect(string IP)
        {
            client = new TcpClient();
            // IP - Порт(совпадает с сервером)
            client.Connect(IP, PORT); // 192.168.0.102
            netstream = client.GetStream();
        }
        public Task ReadMessage()
        {
            try
            {
                // Создаем объект BinaryFormatter для десериализации данных
                BinaryFormatter formatter = new BinaryFormatter();
                // Получаем поток NetworkStream для чтения данных
                netstream = client.GetStream();
                MyMessage rec = new MyMessage();
                while (isRead)
                {
                    if (netstream.DataAvailable)
                    {
                        // читаем сообщения
                        rec = (MyMessage)formatter.Deserialize(netstream);
                        // Сообщение о том что группа созданна
                        if (rec._code == "[GROUP_CREATED]")
                        {
                            // если группа созданна, отображаем лобби
                            string temp = view.ShowLobby(client,message,true,netstream,message._user);
                            if (temp == "Exit")
                            {
                                isRead= false;
                            }
                            else if (temp == "[START_GAME]") 
                            {
                                // должны показать начальную игру
                                string res = view.ShowFirstGame(message._user);
                                if (res != "Exit")
                                {
                                    SendMessage("[ImREADY]", res);
                                }
                                else
                                {
                                    isRead = false;
                                    break;
                                }
                            }
                        }
                        // мы присоединились
                        else if (rec._code == "[CONNECTED]")
                        {
                            // список игроков которые там уже есть
                            List<string> players = rec._message.Split('|').ToList();
                            SendMessage("[CONNECTED]", null);
                            string res = "Exit";
                            res =  view.ShowLobby(client, message,false,netstream,message._user, players);
                            if (res == "Exit")
                            {
                                isRead = false;
                            }
                            else if (res == "[START_GAME]")
                            {
                                // должны показать начальную игру
                                string res2 = view.ShowFirstGame(message._user);
                                if (res2 != "Exit")
                                {
                                    SendMessage("[ImREADY]", res2);
                                }
                                else
                                {
                                    isRead = false;
                                    break;
                                }
                            }
                        }
                        else if (rec._code == "[LIST_GROUP]")
                        {
                            List<string> names = rec._message.Split('|').ToList();
                            string res = view.ShowListGame(names);
                            if (res != null)
                            {
                                message._code = "[CONNECT]";
                                message._message = res;
                                SendMessage();
                            }
                            else 
                            {
                                isRead = false;
                                break;
                            }
                        }
                        else if (rec._code == "[DRAW]")
                        {
                            string[] mes = rec._message.Split('|'); 
                            // в первом хранится имя автора истории
                            // во втором что рисовать
                            Bitmap _res = view.ShowDrawFromTheme(mes[1]);
                            if(_res != null) 
                            {
                                message._code = "[DRAW]";
                                message._message = mes[0];
                                message._bitmap = _res;
                                SendMessage();
                            }
                            else
                            {
                                isRead = false;
                                break;
                            }
                        }
                        else if (rec._code == "[THEME]")
                        {
                            // я получаю в rec._message автора истории
                            // в rec._bitmap - картинка, которую нужно описать
                            string result = view.ShowPictureDescription(rec._bitmap);
                            if (result != null)
                            {
                                message._code = "[THEME]";
                                message._message = string.Join("|",rec._message, result);
                                message._bitmap = null;
                                SendMessage();
                            }
                            else
                            {
                                isRead = false;
                                break;
                            }
                        }
                        // получение истории игры
                        else if (rec._code == "[ENDGAME]")
                        {
                            string res = view.ShowHistory(client,message,netstream);
                            if (res != null) 
                            {
                                break;
                            }
                            else
                            {
                                break;
                            }
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
                netstream.Close();
                client.Close();
                isRead = false;
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Task.CompletedTask;
        }
        private async void SendMessage(string _code, string _message)
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
                netstream.Close();
                client.Close();
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SendMessage()
        {
            try
            {
                if (client.Connected)
                {
                    formatter.Serialize(netstream, message);
                    await netstream.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                netstream.Close();
                client.Close();
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

