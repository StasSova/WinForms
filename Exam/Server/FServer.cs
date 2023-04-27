using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public partial class FServer : Form
    {
        [Serializable]
        struct Message
        {
            public string mes;  // текст сообщения
            public string host; // имя хоста
            public string user; // имя пользователя
        }
        public SynchronizationContext uiContext; // конекст синхронизации
        public FServer()
        {
            InitializeComponent();
            // Получим контекст синхронизации для текущего потока 
            uiContext = SynchronizationContext.Current;
        }
        private async void WaitClientQuery()
        {
            await Task.Run(() =>
            {
                try
                {
                    // TcpListener ожидает подключения от TCP-клиентов сети.
                    TcpListener listener = new TcpListener(
                    IPAddress.Any /* Предоставляет IP-адрес, указывающий, что сервер должен контролировать действия клиентов на всех сетевых интерфейсах.*/,
                    49152 /* порт */);
                    listener.Start(); // Запускаем ожидание входящих запросов на подключение
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
                    uiContext.Send(d =>listBox2.Items.Add("Сервер: "+ex.Message), null);
                }
            });
        }
        private async void ReadMessage(TcpClient client)
        {
            await Task.Run(() =>
            {
                try
                {
                    // Получим объект NetworkStream, используемый для приема и передачи данных.
                    NetworkStream netstream = client.GetStream();
                    Message m = default(Message);
                    do
                    {
                        byte[] arr = new byte[client.ReceiveBufferSize /* размер приемного буфера */];
                        // Читаем данные из объекта NetworkStream.
                        int len = netstream.Read(arr, 0, client.ReceiveBufferSize);
                        if (len > 0)
                        {
                            // Создадим поток, резервным хранилищем которого является память.
                            MemoryStream stream = new MemoryStream(arr);
                            // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                            BinaryFormatter formatter = new BinaryFormatter();
                            m = (Message)formatter.Deserialize(stream); // выполняем десериализацию
                                                                        // полученную от клиента информацию добавляем в список
                                                                        // uiContext.Send отправляет синхронное сообщение в контекст синхронизации
                                                                        // SendOrPostCallback - делегат указывает метод, вызываемый при отправке сообщения в контекст синхронизации. 
                            uiContext.Send(d => listBox1.Items.Add(m.user + m.mes) /* Вызываемый делегат SendOrPostCallback */,
                                null /* Объект, переданный делегату */); // добавляем в список имя клиента
                            stream.Close();
                        }
                        netstream.Close();
                    } while (m.mes != "[END_CONNECTION]");
                    client.Close(); // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.

                }
                catch (Exception ex)
                {
                    client.Close(); // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.
                    uiContext.Send(d => listBox2.Items.Add(ex.Message), null);
                }
                finally { client.Close(); }
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WaitClientQuery();
        }
    }
}
