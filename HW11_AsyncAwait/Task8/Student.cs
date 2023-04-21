using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task8
{
    internal class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int NumberGroup { get; set; }
        public int PhysicsGrade { get; set; }
        public int MathGrade { get; set; }
        public int InformGrade { get; set; }
        public DateTime LastExam { get; set; }
        public Student(string name, int numberGroup, int physicsGrade, int mathGrade, int informGrade, DateTime lastExam)
        {
            Name = name;
            NumberGroup = numberGroup;
            PhysicsGrade = physicsGrade;
            MathGrade = mathGrade;
            InformGrade = informGrade;
            LastExam = lastExam;
        }
        public int CompareTo(Student other)
        {
            // Сортировка по средним оценкам по всем предметам
            int AverageGrade = (PhysicsGrade + MathGrade + InformGrade)/3;
            int otherAverageGrade = (other.PhysicsGrade + other.MathGrade + other.InformGrade)/3;
            if (AverageGrade > otherAverageGrade)
            { // если у нас больше
                return 1;
            }
            else if (AverageGrade < otherAverageGrade)
            { // если у нас меньше
                return -1;
            }
            else
            { // если равно
                return 0;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Group: {NumberGroup}, Last exam: {LastExam.ToShortDateString()}, P:{PhysicsGrade},M:{MathGrade},I:{InformGrade} , A: {(PhysicsGrade + MathGrade + InformGrade) /3}";
        }
    }
}
