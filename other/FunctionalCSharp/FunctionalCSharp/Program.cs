using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalCSharp.Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            var testDates = new List<DateTime>
            {
                DateTime.Parse("2015-01-03"),
                DateTime.Parse("2015-04-12"),
                DateTime.Parse("2015-06-20"),
                DateTime.Parse("2015-10-31"),
                DateTime.Parse("2015-12-24")
            };

            // PART 1:
            //var range = new DateRange { Start = DateTime.Parse("2015-05-31"), End = DateTime.Parse("2015-11-30") };

            //testDates.ForEach(d =>
            //{
            //    var myDates = $"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}";
            //    Console.WriteLine(myDates);
            //});

            //range.End = DateTime.MaxValue;

            //Console.WriteLine("The End property has changed so therefore the LINQ query results changed.");
            //Console.WriteLine("This means that the DateRange type is mutable. To follow the functional");
            //Console.WriteLine("programming paradigm, the type should be immutable.");

            //testDates.ForEach(d =>
            //{
            //    var myDates = $"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}";
            //    Console.WriteLine(myDates);
            //});


            // PART 2:
            var range = new DateRange(DateTime.Parse("2015-05-31"), DateTime.Parse("2015-11-30"));

            testDates.ForEach(d =>
            {
                var myDates = $"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}";
                Console.WriteLine(myDates);
            });

            // The Main() method still wants to change the range's end date.
            // So we can create a new date range and use it instead.
            // By creating a new DateRange instance, we more clearly expressed
            // that range and range2 represent different date ranges and we've done
            // it without altering the original values. 

            var range2 = new DateRange(range.Start, DateTime.MaxValue);
            Console.WriteLine();

            testDates.ForEach(d =>
            {
                var myDates = $"{d:yyyy-MM-dd} - {(range2.DateIsInRange(d))}";
                Console.WriteLine(myDates);
            });

            //range.Slide(28);
            //Console.WriteLine();

            //testDates.ForEach(d =>
            //{
            //    var myDates = $"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}";
            //    Console.WriteLine(myDates);
            //});

            // PART 3:
            // DateRange is immutable from outside the class but with a method like Slide(),
            // it's still mutable within the class. Private readonly fields would need to be added.

            var range3 = range.Slide(28);
            Console.WriteLine();

            testDates.ForEach(d =>
            {
                var myDates = $"{d:yyyy-MM-dd} - {(range3.DateIsInRange(d))}";
                Console.WriteLine(myDates);
            });

            Console.ReadLine();
        }
    }
}
