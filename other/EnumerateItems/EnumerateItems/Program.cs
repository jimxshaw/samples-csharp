using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerateItems
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] daysOfWeek =
            //{
            //    "Monday",
            //    "Tuesday",
            //    "Wednesday",
            //    "Thursday",
            //    "Friday",
            //    "Saturday",
            //    "Sunday"
            //};

            //DisplayItems(daysOfWeek);
            //Console.WriteLine();
            //DisplayItems("String collection test!");

            var days = new List<string>()
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            foreach (var day in days)
            {
                // Enumerators cannot modify the collection
                // while enumerating the collection.

                //days[1] = "2nd day";
                Console.WriteLine(day);

            }

            Console.ReadLine();
        }

        public static void DisplayItems<T>(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                bool moreItems = enumerator.MoveNext();
                while (moreItems)
                {
                    T item = enumerator.Current;
                    Console.WriteLine(item);
                    moreItems = enumerator.MoveNext();
                }
            }

            /*
                This DisplayItems method is essentially this:
                foreach (T item in collection) 
                {
                    Console.WriteLine(item);
                }
            */
        }
    }

}
