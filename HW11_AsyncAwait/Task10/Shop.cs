using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_AsyncAwait.Task10
{
    internal class Shop
    {
        public List<Product> products { get; set; }
        public Shop() { products = new List<Product>(); }
        public Shop(List<Product> products) { this.products= products; }
        public void Add(Product product) { products.Add(product);}
        public void Remove(Product product) { products.Remove(product);}
    }
}
