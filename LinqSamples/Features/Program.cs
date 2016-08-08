using System;
using System.Collections.Generic;

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
                }
            };

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}
