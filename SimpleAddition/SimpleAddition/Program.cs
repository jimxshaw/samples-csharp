using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            string userInput = Console.ReadLine();
            int number1 = int.Parse(userInput);

            Console.Write("Enter the second number: ");
            userInput = Console.ReadLine();
            int number2 = int.Parse(userInput);

            Console.WriteLine("The sum is: {0}", (number1 + number2));
            Console.ReadLine();
        }
    }
}
