using MessageDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Models
{
    public partial class fHistory : Form
    {
        bool isRead = true;
        private int yPos = 5;
        // Не могу использовать класс, в котором происходит связь с сервером,
        // поскольку тот поток заблокирован
        TcpClient client;
        NetworkStream netstream;
        SynchronizationContext uiContext;
        public fHistory(bool isBlack, TcpClient client)
        {
            InitializeComponent();
            if (isBlack)
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                panel1.BackgroundImage = Properties.Resources.black_background;
            }
            this.client = client;
            this.netstream = client.GetStream();
            uiContext = SynchronizationContext.Current;
            button1.Enabled = false;
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
            if (bitmap.Tag != null)
                pictureBox.BackColor = (Color)bitmap.Tag;
            panel1.Controls.Add(pictureBox);

            // обновляем текущую позицию по оси Y на основе координаты добавленного элемента
            yPos += 10 + pictureBox.Size.Height + 10;
            panel1.VerticalScroll.Value = oldpos;
        }
        public void AddNewPlayer()
        {
            int oldpos = panel1.VerticalScroll.Value;
            panel1.VerticalScroll.Value = 0;

            // Picture Box
            PictureBox pictureBox = new PictureBox();
            // Создаем Bitmap для хранения прямоугольника
            Bitmap bmp = new Bitmap(panel1.Width - 20, 10);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // задаем цвет заливки
                Brush brush = new SolidBrush(Color.Red);
                g.FillRectangle(brush, 0, 0, bmp.Width - 1, bmp.Height - 1);
            }
            // Устанавливаем изображение на PictureBox
            pictureBox.Image = bmp;
            pictureBox.Size = bmp.Size; // устанавливаем размер уменьшенного изображения
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
            string author = null;
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
                            if (author == null || author != mes[0])
                            {
                                author = mes[0];
                                AddNewPlayer();
                            }
                            rec._bitmap.Tag = rec._color;
                            AddOneHistory(mes[1], rec._bitmap);
                        }, null);
                    }
                    else if (rec._code == "[ENDHISTORY]")
                    {
                        uiContext.Send(d =>
                        {
                            button1.Enabled = true;
                            isRead = false;
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

        private void fHistory_Load_1(object sender, EventArgs e)
        {
            ReadMessage();
        }
    }
}
