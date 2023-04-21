using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.NewFolder1
{
    internal class Employee1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string NumberPhone { get; set; }
        public string Street { get; set; }
        public int NumberHouse { get; set; }
        public int NumberRoom { get; set; }

        public Employee1 () { }
        public Employee1(string firstName, string lastName, DateTime birthDay, string numberPhone, string street, int numberHouse, int numberRoom)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            NumberPhone = numberPhone;
            Street = street;
            NumberHouse = numberHouse;
            NumberRoom = numberRoom;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} -  {NumberPhone} - st.{Street},{NumberHouse}";
        }
    }
}
