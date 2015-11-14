using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // var number = int.Parse("xyz");

            int number;
            var result = int.TryParse("xyz", out number);

            if (result)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Conversion failed");
            }

            Console.ReadLine();
        }

        static void UseParams()
        {
            var calculator = new Calculator();

            Console.WriteLine(calculator.Add(5, 4, 3, 2, 1));
            Console.WriteLine(calculator.Add(2, 4, 6, 8, 10, 12, 14));
            Console.WriteLine(calculator.Add(new int[]
            {
                234, 4589, 27, 205, 374
            }));
        }

        static void UsePoints()
        {
            try
            {
                var point = new Point(10, 20);
                var point2 = new Point(67, 12);

                point.Move(new Point(40, 60));
                point.Move(point2);

                Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);

                point.Move(null);

                Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);
            }
            catch (Exception)
            {

                Console.WriteLine("An unexpected error occurred");
            }
        }
    }
}
