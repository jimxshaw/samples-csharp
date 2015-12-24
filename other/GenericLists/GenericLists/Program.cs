using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new List<string>(12) {
                "George Washington",
                "Thomas Jefferson",
                "James Madison",
                "Abraham Lincoln",
                "Theodore Roosevelt"
            };

            Console.WriteLine("Before:");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");

            presidents.Add("Franklin Roosevelt");
            presidents.Add("Harry Truman");
            presidents.Add("John Kennedy");
            presidents.Add("Lyndon Johnson");

            Console.WriteLine("Before:");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");

            foreach (var president in presidents)
            {
                Console.WriteLine(president);
            }

            Console.ReadLine();
        }
    }
}
