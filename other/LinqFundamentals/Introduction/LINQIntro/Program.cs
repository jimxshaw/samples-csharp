using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryEmployees();

            //QueryTypes();

            Console.ReadLine();
        }

        private static void QueryTypes()
        {
            var publicTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where t.IsPublic
                              select t.FullName;

            foreach (var name in publicTypes)
            {
                Console.WriteLine(name);
            }


        }

        private static void QueryEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee {Id = 1, Name = "James", HireDate = new DateTime(2012, 4, 24)},
                new Employee {Id = 2, Name = "George", HireDate = new DateTime(2007, 12, 3)},
                new Employee {Id = 3, Name = "Sara", HireDate = new DateTime(2010, 8, 17)}
            };

            var queryResult = from e in employees
                              where e.HireDate.Year > 2009
                              orderby e.Name
                              select e;

            employees.Add(new Employee { Id = 4, Name = "Laurie", HireDate = new DateTime(2011, 11, 27) });

            // Due to deferred execution, Laurie will appear despite the LINQ
            // query being defined before her Employee object was instantiated.
            foreach (var item in queryResult)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("Hire Date: {0}", item.HireDate.Year);
            }
        }
    }
}
