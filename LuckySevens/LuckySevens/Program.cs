using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySevens
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumberOfSevens = 0;
            Random rng = new Random();

            int die1;
            int die2;

            for (int i = 0; i <= 100; i++)
            {
                die1 = rng.Next(1, 7);
                die2 = rng.Next(1, 7);

                if (die1 + die2 == 7)
                {
                    totalNumberOfSevens++;
                }
            }

            Console.WriteLine("Two dice were rolled 100 times.\nYou rolled {0} sevens.", totalNumberOfSevens);

            Console.ReadLine();
        }
    }
}
