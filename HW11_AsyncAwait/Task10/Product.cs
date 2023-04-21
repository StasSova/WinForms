using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task10
{
    public enum Category
    {
        Meat = 0,
        Dairy = 1,
        Bread = 2
    }
    internal class Product
    {
        public Category category { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateOfManuf { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public Product() { }
        public Product(Category category,string name, string manufacturer, DateTime dateOfManuf, DateTime bestBeforeDate)
        {
            this.category = category;
            Name = name;
            Manufacturer = manufacturer;
            DateOfManuf = dateOfManuf;
            BestBeforeDate = bestBeforeDate;
        }
        public override string ToString()
        {
            return $"{Name} - BestBeforeDate: {BestBeforeDate.ToShortDateString()}";
        }
    }
}
