using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlipRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int coin;
            string userGuess;
            string coinDescription = "tails";
            Random rng = new Random();

            // Ask the user
            Console.Write("Enter your guess, heads or tails (h or t): ");
            userGuess = Console.ReadLine();

            // Get a random number for the coin flip
            coin = rng.Next(0, 2);

            if (coin == 1)
            {
                coinDescription = "heads";
            }

            if ((coin == 0 && userGuess == "t") || (coin == 1 && userGuess == "h"))
            {
                Console.WriteLine("The coin flip was {0}, you win!", coinDescription);
            }
            else
            {
                Console.WriteLine("The coin flip was {0}, you lose.", coinDescription);
            }

            Console.ReadLine();
        }
    }
}
