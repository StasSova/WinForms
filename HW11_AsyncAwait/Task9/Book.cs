using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task9
{
    internal class Book
    {
        public int CardNumber { get; set; }
        public string SurNameAuthors { get; set; }
        public string Name { get; set; }
        public string PublishedHouse { get; set; }
        public DateTime Published { get; set; }

        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }
        public Book() { }
        public Book(int cardNumber, string surNameAuthors, string name, string publishedHouse, DateTime published, DateTime dateOfIssue, DateTime dateOfReturn)
        {
            CardNumber = cardNumber;
            SurNameAuthors = surNameAuthors;
            Name = name;
            PublishedHouse = publishedHouse;
            Published = published;
            DateOfIssue = dateOfIssue;
            DateOfReturn = dateOfReturn;
        }
        public override string ToString()
        {
            return $"{Name} - {DateOfReturn.ToShortDateString()}";
        }
    }
}
