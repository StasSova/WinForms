using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Model;

namespace WindowsFormsApp5
{
    class Controller
    {
        Database db = new Database("Library");
        public List<Book> GetBookName(string bookname)
        {
            return db.FindByName(bookname);
        }
        public List<Book> GetBookAuthor(string Author)
        {
            return db.FindByAuthor(Author);
        }
        public void SaveBook(Book book)
        {
            db.Save(book);
        }
    }
}
