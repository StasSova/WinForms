using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task9
{
    internal class Library
    {
        public List<Book> books { get; set; }
        public Library() { books = new List<Book>(); }
        public Library(List<Book> books) { this.books = books; }

        public void AddBook(Book book) { books.Add(book); }
        public void RemoveBook(Book book) { books.Remove(book); }
    }
}
