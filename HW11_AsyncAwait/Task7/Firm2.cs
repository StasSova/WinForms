using HW11_AsyncAwait.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task7
{
    internal class Firm2
    {
        public List<Employee2> employees { get; set; }
        public Firm2() { employees = new List<Employee2>(); }
        public Firm2(List<Employee2> employees)
        {
            this.employees = employees;
        }
        public void Add(Employee2 employee)
        { this.employees.Add(employee); }
        public void Remove(Employee2 employee)
        { this.employees.Remove(employee); }
    }
}
