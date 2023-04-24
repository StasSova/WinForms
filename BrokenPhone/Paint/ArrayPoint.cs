using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenPhone
{
    // Класс который служит для хренения точек
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
