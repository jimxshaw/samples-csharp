using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorCustom
{
    class Program
    {
        static void Main(string[] args)
        {
            AllDaysOfWeek allDays = new AllDaysOfWeek();

            foreach (string day in allDays)
            {
                Console.WriteLine(day);
            }


            Console.ReadLine();
        }
    }

    public class AllDaysOfWeek : IEnumerable<string>
    {
        // Generic method
        public IEnumerator<string> GetEnumerator()
        {
            // When yield return appears in a method that returns
            // IEnumerator interface, C# assumes you want the compiler to
            // write an enumerator for you.
            // Yield return simply tells the compiler the sequence of values
            // to return.

            Console.WriteLine("Calling generic GetEnumerator: ");
            yield return "Monday";
            yield return "Tuesday";
            yield return "Wednesday";
            yield return "Thursday";
            yield return "Friday";
            yield return "Saturday";
            yield return "Sunday";

        }

        // Non-generic legacy method
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
