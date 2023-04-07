using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW03_Form
{
    internal interface IChecked
    {
        bool CheckFirstname(string st);
        bool CheckLastname(string st);
        bool CheckPhone(string st);
        bool CheckEmail(string st);
    }
    class DefaultChecked : IChecked
    {
        public bool CheckEmail(string st)
        {
            string check = @"^(\D+)(\d+)@gmail.com$";
            Regex regex = new Regex(check);
            return regex.IsMatch(st);
        }

        public bool CheckFirstname(string st)
        {
            string check = @"^[A-Za-zА-Яа-я]+$";
            Regex regex = new Regex(check);
            return regex.IsMatch(st);
        }
        public bool CheckLastname(string st)
        {
            string check = @"^[A-Za-zА-Яа-я]+$";
            Regex regex = new Regex(check);
            return regex.IsMatch(st);
        }

        public bool CheckPhone(string st)
        {
            string check = @"^\+38\(\d{3}\)-\d{2}-\d{2}-\d{3}$";
            Regex regex = new Regex(check);
            return regex.IsMatch(st);
        }
    }
}
