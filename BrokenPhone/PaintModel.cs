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
        private bool isMouseDown = false;
        private Pen _pen;
        private Color _color;
        private Graphics _graphics;
        private Bitmap _image;
        private ArrayPoint _points;
        public PaintModel(string text = "Птичка", Bitmap picture = null)
        {
            InitializeComponent();
            //
            // Window
            //

            //
            // TrackBar
            //
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 20;
            trackBar1.Value = 5;
            //
            // Pen
            //
            _color = Color.Black;
            _pen = new Pen(_color, trackBar1.Value);
            _pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //
            // BitMap
            //
            if (picture == null)
            _image = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            else _image = picture;
            //
            // Graphics
            //
            _graphics = Graphics.FromImage(_image);
            //
            // Points
            //
            _points = new ArrayPoint(2);
            //
            // Label
            //
            label3.Text = text;
            if (label3.Text.Length >= 10 && label3.Text.Length < 20)
                label3.Font = new Font(label3.Font.FontFamily, 40, label3.Font.Style);
            else if (label3.Text.Length >= 10 && label3.Text.Length < 20)
                label3.Font = new Font(label3.Font.FontFamily, 30, label3.Font.Style);
            else if (label3.Text.Length >= 20)
                label3.Font = new Font(label3.Font.FontFamily, 20, label3.Font.Style);
            label3.Location = new Point((pictureBox1.Width/2 - label3.Width/2),label3.Location.Y);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown= true;
            Text = "Down";
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            _points.pos = 0;
            Text = "Up";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // перерисовываем 
            Invalidate();
        }

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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _pen.Width = trackBar1.Value;
        }
        private void ChangeColorPen(object sender, EventArgs e)
        {
            _pen.Color = ((Button)sender).BackColor;
        }

        private void ChoiceColors(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _pen.Color = colorDialog1.Color;
        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((Button)ChangeColorBut.Tag).BackColor = colorDialog1.Color;
                _pen.Color = colorDialog1.Color;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            ChangeColorBut.Tag = ((Button)sender);
        }

        // Pen
        private void button6_Click(object sender, EventArgs e)
        {
            _pen.Color = _color;
        }

        // Eraser
        private void button7_Click(object sender, EventArgs e)
        {
            _color = _pen.Color;
            _pen.Color = pictureBox1.BackColor;
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены что хотите очистить полотно?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                _image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = _image;
                _graphics = Graphics.FromImage(_image);
            }
        }

        private void изменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor= colorDialog1.Color;
            }
        }
    }
    class ArrayPoint
    {
        public Point[] points { get; set; }
        public int pos { get; set; }
        public ArrayPoint(int size)
        {
            points = new Point[size];
        }
        public void SetPoints(int x, int y)
        {
            if (pos >= points.Length) pos = 0;
            points[pos] = new Point(x, y);
            pos++;
        }
    }
}
