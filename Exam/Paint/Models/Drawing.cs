using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Paint.Models
{
    internal class Drawing
    {
        private Pen _pen;
        private Color _color;
        private Graphics _graphics;
        private Bitmap _bitmap;
        public Drawing(int Width, int Height)
        {
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
            _pen = new Pen(_color, 2);
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
            _bitmap = new Bitmap(Width, Height);
            #endregion
            //
            // Graphics
            //
            #region
            // Graphics это класс, который предоставляет методы для рисования
            // различных объектов на различных поверхностях визуальных компонентов
            // Создаем объект Graphics, который позволит рисовать на указанном изображении
            _graphics = Graphics.FromImage(_bitmap);
            #endregion
        }
        public void SetSizePen(int size)
        { _pen.Width= size; }
        public void SetColor(Color color)
        { _pen.Color = color; }
        public void ChoicePen()
        { _pen.Color = _color; }
        public void ChoiceEraser(Color BackColor)
        {
            _color= _pen.Color;     // запоминаем предыдущий
            _pen.Color = BackColor; // меняем цвет
        }
        public void Clear(Color BackColor)
        {
            _graphics.Clear(BackColor);
        }
        public Bitmap DrawLine(Point point1,Point point2)
        { 
            _graphics.DrawLine(_pen, point1, point2);
            return _bitmap;
        }
        public Bitmap GetBitmap() { return _bitmap; }
        public void SetBitmap(Bitmap bit) 
        { 
            _bitmap = bit;
            // Создаем новый объект графики
            _graphics = Graphics.FromImage(_bitmap);
        }
    }
}
