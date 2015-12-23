using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            // book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += OnNameChanged;

            //book.Name = "Jim's Grade Book";
            //book.Name = "Grade Book";

            //GetBookName(book);

            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            Console.ReadLine();
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            var stats = book.ComputeStatistics();

            foreach (var grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Summary", stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(92);
            book.AddGrade(67.3f);
            book.AddGrade(58);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Please enter a name");
                book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
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

