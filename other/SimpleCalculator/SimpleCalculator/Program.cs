using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCalculator calc = new SimpleCalculator();
            Console.Write("Enter an integer you want to square: ");
            String input = Console.ReadLine();
            int num = int.Parse(input);

            Console.WriteLine("Your number squared is {0}", calc.Square(num));

            Console.ReadLine();
        }
    }
}
