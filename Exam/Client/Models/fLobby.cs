using MessageDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Models
{
    public partial class fLobby : Form
    {
        private SynchronizationContext uiContext;
        private TcpClient client;
        private NetworkStream netstream;
        MyMessage message = new MyMessage();
        BinaryFormatter formatter = new BinaryFormatter();
        private bool isRead = true;
        private bool isLeader = false;
        public fLobby(bool isBlack, TcpClient client,string players)
        {
            InitializeComponent();
            if (isBlack)
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                button2.BackgroundImage = Properties.Resources.black_background;
                button2.ForeColor = Color.White;

                listBox1.BackColor = Color.Black;
                listBox1.ForeColor = Color.White;
            }
            uiContext = SynchronizationContext.Current;
            this.client = client;
            netstream = client.GetStream();

            string[] _players = players.Split('|');
            if (_players.Length == 1 )  // мы первые -> лидер
            {
                button1.Enabled = true;
                isLeader= true;
            }
            else 
            {  // для других игроков
                button1.Enabled = false;
                button1.Text = "Leader's expectations";
                button2.Text = "Exit";
                button2.DialogResult = DialogResult.Abort;
            }

            foreach (string _player in _players) 
            { 
                listBox1.Items.Add(_player);
            }
        }
        private void fLobby_Load(object sender, EventArgs e)
        {
            ReadMessage();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lock(listBox1)
            {
                // если хотябы 2 человека
                if (listBox1.Items.Count > 1) 
                {
                    // Отправка сообщения о начале игры
                    SendMessage("[START_GAME]", null);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (isLeader)
            {
                // отправляем сообщение об удалении игры
                button2.DialogResult = DialogResult.Cancel;
            }
            else
            {
                // отправляем сообщение об выходе из игры
                button2.DialogResult = DialogResult.Abort;
            }
        }
        public async void ReadMessage()
        {
            // Создаем объект BinaryFormatter для десериализации данных
            BinaryFormatter formatter = new BinaryFormatter();
            // Получаем поток NetworkStream для чтения данных
            MyMessage rec = new MyMessage();
            // чтобы он не вышел
            while (isRead)
            {
                if (netstream.DataAvailable)
                {
                    // читаем сообщения
                    rec = (MyMessage)formatter.Deserialize(netstream);
                    // Кто-то присоединился к игре
                    if (rec._code == "[CONNECTED_TO_GROUP]")
                    {
                        uiContext.Send(d =>
                        {
                            lock (listBox1)
                            {
                                listBox1.Items.Add(rec._message);
                            }
                        }, null);
                    }
                    // начало игры
                    else if (rec._code == "[START_GAME]")
                    {
                        uiContext.Send(d =>
                        {
                            this.DialogResult = DialogResult.OK;
                            isRead = false;
                            this.Close();
                        }, null);
                    }
                    // игра была удалена лидером
                    else if (rec._code == "[EXIT]")
                    {
                        uiContext.Send(d =>
                        {
                            this.DialogResult = DialogResult.Retry;
                            isRead = false;
                            this.Close();
                        }, null);
                    }
                    // Кто-то вышел из игры
                    else if (rec._code == "[REMOVE]")
                    {
                        uiContext.Send(d =>
                        {
                            listBox1.Items.Remove(rec._message);
                        }, null);
                    }
                    else
                    {
                        MessageBox.Show("ошибка чтения");
                    }
                }
                else
                {
                    await Task.Delay(1000);
                }
            }
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
            // в случае ошибки выходим из игры
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                isRead = false;
                this.Close();
            }
        }
        
    }
}
