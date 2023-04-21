using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task8
{
    internal class University
    {
        public List<Student> students { get; set; }
        public University() { students = new List<Student>(); }
        public University (List<Student> students) 
        { this.students = students; }
        public void Add(Student student) { this.students.Add(student);}
        public void Remove(Student student) { this.students.Remove(student);}
    }
}
