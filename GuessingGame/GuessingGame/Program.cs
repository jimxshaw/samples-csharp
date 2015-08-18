using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerGuess;
            string playerInput;
            bool isNumberGuessed = false;
            int theAnswer;

            Random rng = new Random();
            theAnswer = rng.Next(1, 21);

            Console.WriteLine("The answer is greater than 0 but less than 21.");

            do
            {
                Console.Write("Enter your guess: ");
                playerInput = Console.ReadLine();

                playerGuess = int.Parse(playerInput);

                if (playerGuess < 1 || playerGuess > 20)
                {
                    Console.WriteLine("Your guess is out of range. Try again.");
                    continue;
                }

                if (playerGuess == theAnswer)
                {
                    Console.WriteLine("You are correct!");
                    isNumberGuessed = true;
                }
                else
                {
                    if (playerGuess > theAnswer)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else
                    {
                        Console.WriteLine("Too low!");
                    }
                }
            }
            while (!isNumberGuessed);

            Console.ReadLine();
        }
    }
}
