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

            //            var query = cars.Where(c => c.Manufacturer == "Audi" && c.Year == 2016)
            //                            .OrderByDescending(c => c.Combined)
            //                            .ThenBy(c => c.Name)
            //                            .Select(c => c);

            var query = from car in cars
                        orderby car.Combined descending, car.Name ascending
                        select new
                        {
                            car.Manufacturer,
                            car.Name,
                            car.Combined
                        };

            var result = cars.SelectMany(c => c.Name);

            foreach (var character in result)
            {
                Console.WriteLine(character);
            }

            //Console.WriteLine(result);

            //            foreach (var car in query)
            //            {
            //                Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            //            }
        }

        private static List<Car> ProcessFile(string path)
        {

            var query = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ToCar();

            // We could use the query syntax as well.
            //            var queryResult = from line in File.ReadAllLines(path).Skip(1)
            //                              where line.Length > 1
            //                              select Car.ParseFromCsv(line);

            //            return queryResult.ToList();

            return query.ToList();
        }

    }

    // This class will have custom linq operators for when we're creating or querying 
    // our list of cars.
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            // We're assuming we are reading lines from a file.
            foreach (var line in source)
            {
                // Take each line (column) in the csv file and split it by the comma character.
                // Note that the comma is of type char, not string.
                var columns = line.Split(',');

                // Given an incoming source of data, execute some code to transform a string into 
                // a Car type.
                yield return new Car()
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }

        }
    }
}
