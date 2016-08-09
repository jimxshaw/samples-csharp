using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> sales = new Employee[]
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Lara"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "George"
                }
            };

            IEnumerable<Employee> developers = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "James"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Marcus"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Beth"
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Joseph"
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Alex"
                },
                new Employee()
                {
                    Id = 6,
                    Name = "Jose"
                }
            };

            // Func types typically return types.
            Func<int, int> cube = x => x * x * x;
            Func<int, int, int> subtract = (x, y) => x - y;

            // Action types are always void so we only provide the types going in.
            Action<int> writeOut = x => Console.WriteLine(x);

            Console.WriteLine(cube(3));
            Console.WriteLine(subtract(10, 8));

            writeOut(5);

            foreach (var employee in developers.Where(e => e.Name.Length == 4).OrderByDescending(e => e.Name))
            {
                Console.WriteLine($"{employee.Id} - {employee.Name}");
            }
        }

    }
}
