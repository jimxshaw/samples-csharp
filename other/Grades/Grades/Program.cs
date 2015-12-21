using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new GradeBook();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            book.Name = "Jim's Grade Book";
            book.Name = "Grade Book";
            book.AddGrade(92);
            book.AddGrade(67.3f);
            book.AddGrade(58);

            var stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);

            Console.ReadLine();

        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
    }
}
