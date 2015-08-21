using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press enter to star the timer.");
            Console.ReadLine();

            StopWatch myStopWatch = new StopWatch();
            myStopWatch.Start();

            Console.Write("Press enter to stop the timer.");
            Console.ReadLine();
            myStopWatch.Stop();

            Console.ReadLine();
        }
    }
}
