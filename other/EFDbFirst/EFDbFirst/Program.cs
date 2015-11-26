using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDbFirst
{
    public enum Level : byte
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var course = new Course();
            course.Level = Level.Intermediate; // 2

            Console.WriteLine(course.Level);
            
            Console.ReadLine();
        }
    }
}
