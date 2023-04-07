using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HW03_Form
{
    public interface IFile
    {
        void Save(List<Participant> part, string path);
        List<Participant> Load(string path);
    }
    public class TextFile : IFile
    {
        public TextFile() { }
        public List<Participant> Load(string path)
        {
            List<Participant> result = new List<Participant>();
            StreamReader sr = new StreamReader(path);
            try
            {
                string[] strings;
                while (sr.EndOfStream) 
                {
                    // разбиваем считанную строку на отдельные слова
                    strings = sr.ReadLine().Split(new char[]{' '});
                    result.Add(new Participant(strings[0], strings[1], strings[2], strings[3]));
                }
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            sr.Close();
            return result;
        }
        public void Save(List<Participant> part,string path)
        {
            StreamWriter sw = new StreamWriter(path, true);
            for (int i = 0; i > part.Count; i++)
            {
                sw.Write(part[i]);
            }
            sw.Close();
        }
    }
    public class XMLFile : IFile
    {
        public XMLFile() { }
        public List<Participant> Load(string path)
        {
            // куда будет записывать
            List<Participant> result = new List<Participant>();
            // поток (файл, в котором информация)
            FileStream stream = new FileStream(path, FileMode.Open);
            // инструмент для Сериализации/Десериализации
            XmlSerializer serializer = new XmlSerializer(typeof(List<Participant>));
            // процесс Десериализации
            result = (List<Participant>)serializer.Deserialize(stream);
            stream.Close();
            return result;
        }
        public void Save(List<Participant> part, string path)
        {
            // поток (файл, в которую будем записывать информацию)
            FileStream stream = new FileStream(path, FileMode.Create);
            // инструмент для Сериализации/Десериализации
            XmlSerializer serializer = new XmlSerializer(typeof(List<Participant>));
            // процесс Сериализации
            serializer.Serialize(stream, part);
            stream.Close();
        }
    }
}
