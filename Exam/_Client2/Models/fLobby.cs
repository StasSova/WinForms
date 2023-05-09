using MessageDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client2.Models
{
    public partial class fLobby : Form
    {
        // Не могу использовать класс, в котором происходит связь с сервером,
        // поскольку тот поток заблокирован
        MyMessage message;
        TcpClient client;
        BinaryFormatter formatter;

        NetworkStream netstream;
        SynchronizationContext uiContext;
        bool isRead = true;
        public fLobby(TcpClient client,MyMessage mes,bool isLeader, NetworkStream net,string player)
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            formatter = new BinaryFormatter();
            message = mes;
            this.client = client;
            listBox1.Items.Add(player);
            netstream = net;
            // если не лидер группы
            if (!isLeader) 
            { 
                button1.Enabled = false;
            }
        }
        public fLobby(TcpClient client,MyMessage mes,bool isLeader, NetworkStream net, string player, List<string> otherPlayers) : this(client,mes, isLeader,net,player)
        {
            foreach (var item in otherPlayers)
            {
                listBox1.Items.Add(item);
            }
        }
        public void AddPlayer(string player)
        {
            lock(listBox1)
            {
                listBox1.Items.Add(player);
            }
        }
        private void fLobby_Load(object sender, EventArgs e)
        {
            ReadMessage();
        }
        private void fLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRead = false;
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
                    // Сообщение о том что группа созданна
                    if (rec._code == "[CONNECTED_TO_GROUP]")
                    {
                        uiContext.Send(d =>
                        {
                            this.AddPlayer(rec._message);
                        },null);
                    }
                    else if (rec._code == "[START_GAME]")
                    {
                        uiContext.Send(d =>
                        {
                            this.DialogResult = DialogResult.OK;
                            isRead = false;
                            this.Close();
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
            catch (Exception ex)
            {
                netstream.Close();
                client.Close();
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage("[START_GAME]", null);
            isRead = false;
        }
    }
}
