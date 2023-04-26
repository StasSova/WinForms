using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp5.Model
{
    [Serializable]
    public class Book // [DataMember]
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Book() { }
        public Book(string n, string a)
        {
            Name = n;
            Author = a;
        }
        public override string ToString()
        {
            return $"Название: {Name}\tАвтор: {Author}\n";
        }
    }
}
