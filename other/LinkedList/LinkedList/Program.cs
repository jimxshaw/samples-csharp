using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new LinkedList<string>();
            presidents.AddLast("George Washington");
            presidents.AddLast("Thomas Jefferson");
            presidents.AddLast("Abraham Lincoln");
            presidents.AddLast("Theodore Roosevelt");
            presidents.AddLast("Woodrow Wilson");

            presidents.RemoveLast();
            presidents.AddLast("Franklin Roosevelt");

            LinkedListNode<string> jefferson = presidents.Find("Thomas Jefferson");
            presidents.AddAfter(jefferson, "Andrew Jackson");

            foreach (var president in presidents)
            {
                Console.WriteLine(president);
            }

            Console.ReadLine();
        }
    }
}
