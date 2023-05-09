using MessageDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client2.Models
{
    public partial class fHistory : Form
    {
        bool isRead = true;
        private int yPos = 5;
        // Не могу использовать класс, в котором происходит связь с сервером,
        // поскольку тот поток заблокирован
        MyMessage message;
        TcpClient client;
        BinaryFormatter formatter;

        NetworkStream netstream;
        SynchronizationContext uiContext;   
        public fHistory(TcpClient client, MyMessage mes, NetworkStream net)
        {
            InitializeComponent();
            this.client = client;
            this.formatter = new BinaryFormatter();
            this.netstream = net;
            uiContext = SynchronizationContext.Current;
            this.message = mes;

        }
        public void AddOneHistory(string theme, Bitmap bitmap)
        {
            int oldpos = panel1.VerticalScroll.Value;
            panel1.VerticalScroll.Value = 0;
            // Label
            Label label = new Label();
            label.Text = theme;
            label.AutoSize = true; // автоматически определять размер Label
            label.Location = new Point(10, yPos); // использовать текущую позицию по оси Y
            panel1.Controls.Add(label);
            yPos += label.Font.Height + 5;

            // Picture Box
            PictureBox pictureBox = new PictureBox();
            Image thumbImage = bitmap.GetThumbnailImage(bitmap.Width / 2, bitmap.Height / 2, null, IntPtr.Zero);
            pictureBox.Image = thumbImage;
            pictureBox.Size = thumbImage.Size; // устанавливаем размер уменьшенного изображения
            pictureBox.Location = new Point(10, yPos); // добавляем отступ между элементами
            panel1.Controls.Add(pictureBox);

            // обновляем текущую позицию по оси Y на основе координаты добавленного элемента
            yPos += 10 + pictureBox.Size.Height + 10;
            panel1.VerticalScroll.Value = oldpos;
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
                    string[] mes;
                    if (rec._code == "[HISTORY]")
                    {
                        mes = rec._message.Split('|');
                        uiContext.Send(d =>
                        {
                            AddOneHistory(mes[1],rec._bitmap);
                        }, null);
                    }
                    else if (rec._code == "[ENDHISTORY]")
                    {
                        uiContext.Send(d =>
                        {
                            //this.DialogResult = DialogResult.OK;
                            //isRead = false;
                            //this.Close();
                        }, null);
                    }
                    else
                    {
                        MessageBox.Show("ошибка чтения");
                    }
                }
                else
                {
                    await Task.Delay(500);
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

        private void fHistory_Load(object sender, EventArgs e)
        {
            ReadMessage();
        }
    }
}
