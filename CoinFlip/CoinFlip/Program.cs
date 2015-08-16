using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            int coin;
            string userGuess;
            Random rng = new Random();

            // Ask the user
            Console.Write("Enter your guess, heads or tails (h or t): ");
            userGuess = Console.ReadLine();

            // Get a random number for the coin flip
            coin = rng.Next(0, 2);

            if (coin == 0 && userGuess == "t")
            {
                Console.WriteLine("The coin flip was tails, you win!");
            }
            else if (coin == 1 && userGuess == "h")
            {
                Console.WriteLine("The coin flip was heads, you win!");
            }
            else
            {
                if (coin == 0)
                {
                    Console.WriteLine("The coin flip was tails, you lose.");
                }
                else
                {
                    Console.WriteLine("The coin flip was heads65, you lose.");
                }
            }

            Console.ReadLine();
        }
    }
}
