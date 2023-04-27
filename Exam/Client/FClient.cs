using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FClient : Form
    {
        TcpClient client;
        NetworkStream netstream;
        BinaryFormatter formatter;
        SynchronizationContext uiContext;
        string host = Dns.GetHostName();
        string user = Environment.UserName;

        [Serializable]
        struct Message
        {
            public string mes;  // текст сообщения
            public string host; // имя хоста
            public string user; // имя пользователя
        }

        public FClient()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            formatter = new BinaryFormatter();
        }

        private async void Connect()
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync("127.0.0.1", 49152);
                netstream = client.GetStream();
                listBox1.Items.Add("Connected to server.");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private async void SendMessage()
        {
            try
            {
                if (client.Connected)
                {
                    Message m;
                    m.mes = textBox2.Text;
                    m.host = host;
                    m.user = user;
                    formatter.Serialize(netstream, m);
                    await netstream.FlushAsync();
                    listBox1.Items.Add("Message sent.");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private async void ReadMessage()
        {
            await Task.Run(() =>
            {
                try
                {
                    byte[] arr = new byte[client.ReceiveBufferSize];
                    int len = netstream.Read(arr, 0, client.ReceiveBufferSize);
                    if (len > 0)
                    {
                        MemoryStream stream = new MemoryStream(arr);
                        Message m = (Message)formatter.Deserialize(stream);
                        uiContext.Send(d => listBox1.Items.Add(m.host + m.user + m.mes), null);
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(ex.Message);
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReadMessage();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SendMessage();
        }
    }
}
