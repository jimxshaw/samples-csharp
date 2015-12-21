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

            // book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += OnNameChanged;

            //book.Name = "Jim's Grade Book";
            //book.Name = "Grade Book";

            try
            {
                Console.WriteLine("Please enter a name");
                book.Name = Console.ReadLine();

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception)
            {
                Console.WriteLine("Something's wrong");
            }
            

            book.AddGrade(92);
            book.AddGrade(67.3f);
            book.AddGrade(58);
            book.WriteGrades(Console.Out);

            var stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Summary", stats.Description);

            Console.ReadLine();

        }

        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.EvistingName} to {args.NewName}");
        //}

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }
    }
}

