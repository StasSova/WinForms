using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Model
{
    class Database
    {
        FileBook fileBook;
        string FileName;
        public Database(string fileName)
        {
            FileName = fileName;
            fileBook = new FileBook(fileName);
        }
        public List<Book> FindByName(string bookName)
        {
            return fileBook.FindByName(bookName);
        }
        public List<Book> FindByAuthor(string Author) 
        { 
            return fileBook.FindByAuthor(Author);
        }
        public void Save(Book book) 
        {
            fileBook.Save(book);            
        }
    }
}
