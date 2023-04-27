using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    // класс отвечающий за тип хранимых данных
    public class Memento
    {
        // изображение
        public Bitmap bitmap { get; set; }
        // цвет фона
        public Color BackgroundColor { get; set; }
        public Memento(Bitmap bitmap, Color color)
        {
            this.bitmap = bitmap;
            BackgroundColor = color;
        }
    }
    // класс овтечающий за историю хранения данных
    public class Caretaker
    {
        // количество хранимых данных
        private int NumbersMemento { get; set; } = 10;
        // Список хранимых данных
        public List<Memento> history { get; set; }
        public Caretaker() { history = new List<Memento>(); }
        // сохранения данных
        public void Save(Memento memento)
        {
            history.Add(memento);               // добавление в история (конец)
            if (history.Count > NumbersMemento) // если больше чем NumbersMemento
                history.RemoveAt(0);            // удаляем первый (начало)
        }
        // отмена предыдущего действия
        public Memento Undo()
        {
            if (history.Count == 0) return null; // если 
            else
            {
                Memento last = history.Last();  // Берем последний добавленный 
                history.Remove(last);           // удаляем из истории
                return last;                    // возвращаем
            }
        }

    }
}
