using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            Console.WriteLine("Area: {0}", r.GetArea());

            Rectangle r2 = new Rectangle(12, 18);
            Console.WriteLine("Area: {0}", r2.GetArea());

            Console.ReadLine();
        }
    }
}
