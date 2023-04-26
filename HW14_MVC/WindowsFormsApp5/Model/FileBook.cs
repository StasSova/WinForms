using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp5.Model
{
    internal class FileBook
    {
        FileStream stream = null;
        XmlSerializer serializer = null;
        string FileName;
        public FileBook(string FileName)
        {
            this.FileName = FileName;
        }
        public void Save(Book book)
        {
            var books = Load();
            books.Add(book); 
            using (var stream = new FileStream($"{FileName}.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);
            }
        }
        public List<Book> Load()
        {
            if (!File.Exists($"{FileName}.xml")) return new List<Book>();
            using (var stream = new FileStream($"{FileName}.xml", FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                return (List<Book>)serializer.Deserialize(stream);
            }
        }
        public List<Book> FindByName(string Key)
        {
            var l = Load();
            return l.Where(d=> d.Name.Contains(Key)).ToList();
        }
        public List<Book> FindByAuthor(string Key)
        {
            var l = Load();
            return l.Where(d => d.Author.Contains(Key)).ToList();
        }
    }
}
