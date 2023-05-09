using Paint.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Paint
{
    public partial class Draw : Form
    {
        public Bitmap _result { get; set; }
        private Controller _contr;
        private bool isMouseDown = false;
        private int Time;
        public Draw(string text = "Птичка", int time = 5)
        {
            InitializeComponent();
            //
            // Properties Form
            //
            #region
            // KeyPreview - позволяет форме перехватывать клавиатурные события до
            // их достижения элементов управления внутри формы.
            this.KeyPreview = true;
            // Фоновое изображение
            this.BackgroundImage = Properties.Resources.Main_Background;
            // "DoubleBuffered" - предназначено для уменьшения мерцания элементов
            // при их обновлении на форме.
            this.DoubleBuffered = true;
            #endregion
            //
            // TrackBar
            //
            #region
            //TrackBar - Используется для изменения толщины инструмента рисования
            trackBar1.Minimum = 1;      // Минимальное значение  
            trackBar1.Maximum = 20;     // максимальное значение
            trackBar1.Value = 5;        // текущее значение 
            #endregion
            //
            // Controller
            //
            _contr = new Controller(pictureBox1.Width,pictureBox1.Height);
            // 
            // PictureBox 
            // 
            pictureBox1.Image = _contr.GetBitmap();
            //
            // Label
            //
            #region
            // Фон 
            label3.Image = Properties.Resources.Main_Background;
            // Показывает информацию о том, что необходимо нарисовать
            label3.Text = text;
            if (label3.Text.Length >= 10 && label3.Text.Length < 20)
                label3.Font = new Font(label3.Font.FontFamily, 40, label3.Font.Style);
            else if (label3.Text.Length >= 10 && label3.Text.Length < 20)
                label3.Font = new Font(label3.Font.FontFamily, 30, label3.Font.Style);
            else if (label3.Text.Length >= 20)
                label3.Font = new Font(label3.Font.FontFamily, 20, label3.Font.Style);
            label3.Location = new Point((pictureBox1.Width / 2 - label3.Width / 2), label3.Location.Y);
            #endregion
            //
            // Other
            //
            Time = time;
        }

        //
        // Form
        //

        // Вызов - полная загрузка окна и его отображение
        // Корректировка параметров, запуск таймера
        private void Form1_Load(object sender, EventArgs e)
        {
            // Присваиваем текущее значение толщины пера
            _contr.SetSizePen(trackBar1.Value);
            // Корректировка Label 
            label1.Text = $"Толщина: {trackBar1.Value}";
            // Запуск таймера
            label2.Text = $"Осталось: {Time}";
            timer1.Start();
        }
        // Вызов - нажатие клавиши на клавиатуре
        // Отмена последнего действия
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + Z - отмена
            if (e.Control && e.KeyCode == Keys.Z)
            {
                // забираем последений сохраненный снимок
                Memento last = _contr.Undo();
                if (last == null) return;
                // меняем цвет фона на предыдущий
                pictureBox1.BackColor = last.BackgroundColor;
                // устанавливаем новую картинку
                _contr.SetBitmap(last.bitmap);
                // так как указатель указывает на другой объект, 
                // обновим указатель и на полотне
                pictureBox1.Image = _contr.GetBitmap();
                // Refresh - обновляет содержимое PictureBox
                pictureBox1.Refresh();
            }
        }

        //
        // Pen
        //

        // Вызов - цветные кнопки
        // Изменение цвета пера
        private void ChangeColorPen(object sender, EventArgs e)
        { _contr.SetColorPen(((Button)sender).BackColor); }
        // Вызов - кнопка с карандашом
        // Имитация изменения инструмента на перо
        private void button6_Click(object sender, EventArgs e)
        {  _contr.ChoicePen(); }
        // Вызов - кнопка с ластиком
        // Имитация изменения инструмента на ластик
        private void button7_Click(object sender, EventArgs e)
        { _contr.ChoiceEraser(pictureBox1.BackColor); }

        //
        // TrackBar
        // 

        // Вызов - TrackBar
        // меняем тощину инструмента рисования
        private void trackBar1_Scroll(object sender, EventArgs e)
        { 
            _contr.SetSizePen(trackBar1.Value);
            label1.Text = $"Толщина: {trackBar1.Value}";
        }

        //
        // Color buttons
        //

        // Вызов - правая кнопка на цветную кнопку (Контекстное меню)
        // изменения цвета кнопки
        private void изменитьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем окно
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // достаем из хранимого объекта контекстого меню кнопку
                // и ей присваиваем цвет
                ((Button)contextMenuStrip1.Tag).BackColor = colorDialog1.Color;
                // сразу меняем цвет кнопки
                _contr.SetColorPen(colorDialog1.Color);
            }
        }
        // Вызов - щелчек кнопки на цветную кнопку
        // запоминание кнопки, по которой был щелчек
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            // правая кнопка мышки
            if (e.Button == MouseButtons.Right)
                // в ContextMenuItem сохраняем по какой кнопке было нажато 
                // Tag - служит для хранения объектов
                contextMenuStrip1.Tag = ((Button)sender);
        }
        // Вызов - клик по серой кнопке
        // изменение цвета пера
        private void button8_Click(object sender, EventArgs e)
        {
            // вызываем окно
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // меняем цвет пера
                _contr.SetColorPen(colorDialog1.Color);
            }
        }

        //
        // Picture Box
        //
        
        // Вызов - перемещение по полотну мышкой
        // ПРОЦЕС РИСОВАНИЯ (При зажатой кнопке)
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // если кнопка поднята ничего не делать
            if (!isMouseDown) return;
            // указываем первую точку
            _contr.SetPoints(e.X, e.Y);
            // если точка только одна, ничего не рисуем
            if (_contr.GetPos() < 2) return;
            // рисуем линию на BitMap-е и отображаем на PictureBox
            _contr.DrawLine();
            // Refresh - обновляет содержимое PictureBox
            pictureBox1.Refresh();
            // забираем координаты точки 
            _contr.SetPoints(e.X, e.Y);
        }

        // Вызов - правая кнопка по полотну (Контекстное меню)
        // Очистка полотна
        private void очиститьФонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены что хотите очистить полотно?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                // на всякий случай сохраняем 
                _contr.Save(new Bitmap(pictureBox1.Image), pictureBox1.BackColor);
                // Очищаем BitMap
                _contr.ClearImage(pictureBox1.BackColor);
                // Refresh - обновляет содержимое PictureBox
                pictureBox1.Refresh();
            }
        }
        // Вызов - отпускание кнопки мышки
        // Изменение bool переменной, изменение позиции в ArrayPoint
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // если поднята левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;    // меняем значения
                // нужно для того, чтобы когда мы будет рисовать следующий раз
                // рисование не начиналось с предыдущей точки
                _contr.SetPos(0);
            }
        }
        // Вызов - щелчек кнопки мышки
        // Изменение bool переменной, сохранения состояния полотна
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // изменяем значения поля 
                isMouseDown = true;  
                // Сохраняем текущее состояние полотна
                _contr.Save(new Bitmap(pictureBox1.Image), pictureBox1.BackColor);
            }
        }
        // Вызов - правая кнопка мышки на полотне
        // Смена цвета полотна
        private void изменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем окно
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // запоминаем предыдущее состояние
                _contr.Save(new Bitmap(pictureBox1.Image), pictureBox1.BackColor);
                // меняем цвет полотна
                pictureBox1.BackColor = colorDialog1.Color;
                // Refresh - обновляет содержимое PictureBox
                pictureBox1.Refresh();
            }
        }
        
        //
        // Timer
        //

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = $"Осталось: {--Time}";
            if (Time == 0)
            {
                timer1.Stop();
                _result = (Bitmap)pictureBox1.Image;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            _result = (Bitmap)pictureBox1.Image;
        }
    }
}
