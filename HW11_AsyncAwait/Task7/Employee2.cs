using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task7
{
    internal class Employee2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PlaceOfBirth { get; set; }
        public Employee2() { }
        public Employee2(string firstName, string lastName, DateTime birthDay, string placeOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            PlaceOfBirth = placeOfBirth;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} - {BirthDay}";
        }
    }
}
