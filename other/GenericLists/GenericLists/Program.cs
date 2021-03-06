﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1:
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

            // var copy = presidents.AsReadOnly();
            // The above line does the exact same thing as
            // the below line. In fact, the below line is
            // what's occuring under the hood.
            var copy = new ReadOnlyCollection<string>(presidents);


            //BadCode(copy);


            foreach (var president in presidents)
            {
                Console.WriteLine(president);
            }

            Console.WriteLine();






            // Part 2:
            var lst = new NonBlankStringList();
            lst.Add("Item added at index 0");
            lst[0] = "   ";
            lst.Add("Item added at index 1");
            lst.Insert(2, "Item inserted at index 2");

            foreach (string item in lst)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }

        static void BadCode(IList<string> lst)
        {
            lst.RemoveAt(2);
        }
    }
}
