using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() {}
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
    namespace MyStudent
    { 
        public class Student: Person 
        { 
            public string Academy { get; set; }
            public Student() : base() { }
            public Student(string name, int age,string academy) : base(name,age) 
            {
                Academy = academy;
            }
        }
    }
}
