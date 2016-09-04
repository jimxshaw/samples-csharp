using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            // Sort all cars by combined fuel efficiency descending and then sort it by 
            // car name in ascending order.

            //            var query = cars.OrderByDescending(car => car.Combined)
            //                            .ThenBy(c => c.Name)
            //                            .ToList();

            var query = from car in cars
                        orderby car.Combined descending, car.Name ascending
                        select car;

            foreach (var car in query.ToList().Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            // Given the path to our data source file, read all lines from it if 
            // the line's length is at least 1. Also, skip the first line because 
            // that's the file column header line. Then map each line of type string 
            // into an object of type Car by using the Car's own ParseFromCsv method that we wrote 
            // ourselves. We could have passed into Select a complex lambda expression 
            // but using a method is easier.

            //            return File.ReadAllLines(path)
            //                .Skip(1)
            //                .Where(line => line.Length > 1)
            //                .Select(Car.ParseFromCsv).ToList();

            // We could use the query syntax as well.
            var queryResult = from line in File.ReadAllLines(path).Skip(1)
                              where line.Length > 1
                              select Car.ParseFromCsv(line);

            return queryResult.ToList();
        }

    }
}
