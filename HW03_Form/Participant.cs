using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW03_Form
{
    [Serializable]
    [DataContract]
    public class Participant: IComparable<Participant>
    {
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public string NumberPhone { get; set; }
        [DataMember] public string Email { get; set; }
        public Participant() { }
        public Participant(string firstName, string lastName, string email, string numberPhone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NumberPhone = numberPhone;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {NumberPhone} {Email}";
        }
        public override bool Equals(object obj)
        {
            Participant other = (Participant)obj;
            return  FirstName == other.FirstName &&
                    LastName == other.LastName &&
                    NumberPhone == other.NumberPhone &&
                    Email == other.Email;
        }
        public int CompareTo(Participant other)
        {
            int result = FirstName.CompareTo(other.FirstName);
            if (result == 0) { result = LastName.CompareTo(other.LastName); }
            if (result == 0) { result = NumberPhone.CompareTo(other.NumberPhone); }
            if (result == 0) { result = Email.CompareTo(other.Email); }
            return result;
        }
    }
}
