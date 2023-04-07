using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HW03_Form
{
    public class ListPart
    {
        public List<Participant> participants { get; set; }
        public IFile FileMan { get; set; }
        public ListPart() { 
            participants = new List<Participant>();
            FileMan = new XMLFile();
        }
        public ListPart(List<Participant> participants): base() {
            this.participants = participants;
        }
        public void Add(Participant participant)
        { this.participants.Add(participant); }
        public void Remove(Participant participant) 
        { this.participants.Remove(participant); }
        public void Save(string path)
        { FileMan.Save(participants,path); }
        public void Load(string path) 
        { participants = FileMan.Load(path); }
    }
}
