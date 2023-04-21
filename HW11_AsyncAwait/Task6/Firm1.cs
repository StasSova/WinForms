using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.NewFolder1
{
    internal class Firm1
    {
        public List<Employee1> employees { get; set; }
        public Firm1() { employees = new List<Employee1>(); }
        public Firm1(List<Employee1> employees)
        {
            this.employees = employees;
        }
        public void Add(Employee1 employee)
        { this.employees.Add(employee);}
        public void Remove(Employee1 employee) 
        { this.employees.Remove(employee);}
    }
}
