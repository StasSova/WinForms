using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                IntPtr a = new IntPtr(10);
                Console.WriteLine(a);
            }
        }
    }
}
