using Paint.ExtraClass;
using Paint.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    internal class Controller
    {
        private Drawing drawing;
        private Caretaker caretaker;
        private ArrayPoint _arr;
        // Инициализация
        public Controller(int PictureWidth, int PictureHeight)
        {
            drawing = new Drawing(PictureWidth, PictureHeight);
            caretaker = new Caretaker();
            _arr = new ArrayPoint(2);
        }

        //
        // PEN
        //

        // Смена толщины рисования
        public void SetSizePen(int size)
        { drawing.SetSizePen(size); }
        // Смена цвета рисования
        public void SetColorPen(Color color)
        { drawing.SetColor(color); }
        // выбор пера
        public void ChoicePen()
        { drawing.ChoicePen(); }
        // выбор ластика 
        public void ChoiceEraser(Color BackColor)
        { drawing.ChoiceEraser(BackColor); }

        //
        // DRAWING
        // 

        // очистка полотна
        public void ClearImage(Color BackColorPictureBox)
        { drawing.Clear(BackColorPictureBox); }
        // Рисование линии
        public Bitmap DrawLine()
        { return drawing.DrawLine(_arr.points[0], _arr.points[1]); }
        public Bitmap GetBitmap() 
        { return drawing.GetBitmap(); }
        public void SetBitmap(Bitmap bit)
        { drawing.SetBitmap(bit);}
        //
        // ARRAY POINT
        //

        public void SetPos(int pos)
        { _arr.pos= pos; }
        public int GetPos()
        { return _arr.pos; }
        public void SetPoints(int x, int y)
        { _arr.SetPoints(x, y); }

        //
        // BITMAP HISTORY
        //

        // Сохранения состояния картинки
        public void Save(Bitmap bitmap,Color BackColor)
        { caretaker.Save(new Memento(bitmap, BackColor)); }
        // Возврат последнего сохраненного состояния
        public Memento Undo()
        { return caretaker.Undo(); }
    }
}
