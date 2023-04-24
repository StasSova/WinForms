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

namespace BrokenPhone
{
    public partial class PaintModel : Form
    {
        // нажата ли левая кнопка мыши
        private bool isMouseDown = false;
        private Pen _pen;
        private Color _color;
        private Graphics _graphics;
        private Bitmap _image;
        private ArrayPoint _points;
        private Caretaker _caretaker;
        // инициализация
        public PaintModel(string text = "Птичка", Bitmap picture = null)
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
            // Memento
            //
            #region
            // Memento - используется для хранения состояний полотна
            _caretaker = new Caretaker();
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
            // Color
            //
            #region
            // Color - класс для хранения цвета, в данном случае используется 
            // для изменения цвета инструмента рисования
            _color = Color.Black;
            #endregion
            //
            // Pen
            //
            #region
            // Pen - инструмент рисования
            // инициализация (цвет, толщина)
            _pen = new Pen(_color, trackBar1.Value);
            // стиль начальной точки линии (плоский, квадратный, круглый и т. д.)
            _pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            // стиль конечной точки линии (плоский, квадратный, круглый и т. д.)
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            #endregion
            //
            // BitMap
            //
            #region
            // Рисунок который находится на полотне
            // Если мы ничего не передаем форме
            if (picture == null)
                // Иницализируем новым рисунком с размерами, соответсвующими
                // высоте и ширине елемента управления PictureBox
                _image = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            else _image = picture;
            #endregion
            //
            // Graphics
            //
            #region
            // Graphics это класс, который предоставляет методы для рисования
            // различных объектов на различных поверхностях визуальных компонентов
            // Создаем объект Graphics, который позволит рисовать на указанном изображении
            _graphics = Graphics.FromImage(_image);
            #endregion
            //
            // Points
            //
            #region
            // Создаем объект ArrayPoint, который будет соответсвовать 
            // 1й и 2й точки, между которыми будем рисовать линию
            _points = new ArrayPoint(2);
            #endregion
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
            label3.Location = new Point((pictureBox1.Width/2 - label3.Width/2),label3.Location.Y);
            #endregion
        }
        
        //
        // Form
        //

        // обработчик нажатия клавиш 
        private void PaintModel_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + Z - отмена
            if (e.Control && e.KeyCode == Keys.Z)
            {
                // если история не пуста
                if (_caretaker.history.Count > 0)
                {
                    Memento mem = _caretaker.Undo();
                    Text = "Отмена"; // УДАЛИТЬ
                    // присваиваем BitMap последнее сохраненное изображение
                    _image = mem.bitmap;
                    // меняем картинку 
                    pictureBox1.Image = _image;
                    // меняем фон
                    pictureBox1.BackColor = mem.BackgroundColor;
                    // Создаем новый объект графики
                    _graphics = Graphics.FromImage(_image);
                }
                else // УДАЛИТЬ
                {
                    Text = "Конец";
                }
            }
        }

        // 
        // PictureBox
        // 

        // обработчик PictureBox нажания кнопки мышки
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown= true;  // изменяем значения поля 
                Text = "Save";      // УДАЛИТЬ 
                // Сохраняем текущее состояние полотна
                _caretaker.Save(new Memento(new Bitmap(_image),pictureBox1.BackColor));
            }
        }
        // обработчик PictureBox поднятия кнопки мышки
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // если поднята левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;    // меняем значения
                // нужно для того, чтобы когда мы будет рисовать следующий раз
                // рисование не начиналось с предыдущей точки
                _points.pos = 0;
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // перерисовываем (когда меняется цвет фона)
            Invalidate();
        }
        // Обработчик движения мышки
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            // если кнопка поднята ничего не делать
            if (!isMouseDown) return;
            Text = e.Location.ToString();
            // указываем первую точку
            _points.SetPoints(e.X, e.Y);
            // если точка только одна, ничего не рисуем
            if (_points.pos < 2) return;
            // рисуем линию на BitMap-е 
            _graphics.DrawLine(_pen, _points.points[0], _points.points[1]);
            // отображаем на PictureBox
            pictureBox1.Image = _image;
            // забираем координаты точки 
            _points.SetPoints(e.X,e.Y);

        }

        // 
        // ContextMenuItem PictureBox 
        // 

        // Обработчик клика на очистку экрана
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены что хотите очистить полотно?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                // Очищаем BitMap
                _graphics.Clear(pictureBox1.BackColor);
                // Refresh - обновляет содержимое PictureBox
                pictureBox1.Refresh();
            }
        }
        // Обработчик клика на изменения цвета фона PictureBox экрана
        private void изменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем палитру
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // меняем цвет
                pictureBox1.BackColor = colorDialog1.Color;
                _caretaker.Save(new Memento(new Bitmap(_image), pictureBox1.BackColor));
            }
        }

        // 
        // ContextMenuItem ColorButton 
        // 

        // при нажатии мышкой по кнопке
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            // правая кнопка мышки
            if (e.Button == MouseButtons.Right)
                // в ContextMenuItem сохраняем по какой кнопке было нажато 
                // Tag - служит для хранения объектов
                ChangeColorBut.Tag = ((Button)sender);
        }
        // Обработчик смены цвета кнопки (правый клик на кнопку)
        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем окно
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // достаем из хранимого объекта контекстого меню кнопку
                // и ей присваиваем цвет
                ((Button)ChangeColorBut.Tag).BackColor = colorDialog1.Color;
                // сразу меняем цвет кнопки
                _pen.Color = colorDialog1.Color;
            }
        }

        //
        // TrackBar
        //

        // Обраточкик изменения значения на TrackBar ел-те
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // меняем тощину инструмента рисования
            _pen.Width = trackBar1.Value;
        }

        //
        // ColorButton
        //

        // Обработчик нажатия на кнопки с цветом
        private void ChangeColorPen(object sender, EventArgs e)
        {
            // изменяем цвет инструмента рисования на цвет кнопки
            _pen.Color = ((Button)sender).BackColor;
        }
        // Обработчик кнопки, который показывает всю палитру цветов
        private void ChoiceColors(object sender, EventArgs e)
        {
            // вызываем окно
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                // меняем цвет инструмента рисования
                _pen.Color = colorDialog1.Color;
        }


        //
        // Инструменты рисования
        //
        // Pen (ручка)
        private void button6_Click(object sender, EventArgs e)
        {
            // восстанавливаем цвет
            _pen.Color = _color;
        }
        // Eraser (ластик)
        private void button7_Click(object sender, EventArgs e)
        {
            // запоминаем цвет
            _color = _pen.Color;
            // ставим ручке цвет фона полотна
            // (еффект ластика)
            _pen.Color = pictureBox1.BackColor;
        }
    }
   
}
