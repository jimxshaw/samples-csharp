using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RockPaperScissorsGame
    {
        private Random rng;
        private int wins;
        private int losses;
        private int ties;

        public RockPaperScissorsGame()
        {
            rng = new Random();
        }

        public void Play()
        {
            string userChoice;
            userChoice = PromptUser();

            while (userChoice != "q")
            {
                string computerChoice = GetComputerChoice();
                DetermineWinner(userChoice, computerChoice);
                PrintScore();
                Console.Clear();
                userChoice = PromptUser();
            }
        }

        private void PrintScore()
        {
            Console.WriteLine();
            Console.WriteLine("Wins: {0}", wins);
            Console.WriteLine("Losses: {0}", losses);
            Console.WriteLine("Ties: {0}", ties);
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private void DetermineWinner(string userChoice, string computerChoice)
        {
            if (userChoice == computerChoice)
            {
                ties++;
                Console.WriteLine("It's a tie. You both picked {0}.", ConvertChoiceToWord(userChoice));
            }
            else if ((userChoice == "r" && computerChoice == "s") || (userChoice == "s" && computerChoice == "p") || (userChoice == "p" || computerChoice == "r"))
            {
                wins++;
                Console.WriteLine("You win! Your {0} defeats computer's {1}!", ConvertChoiceToWord(userChoice), ConvertChoiceToWord(computerChoice));
            }
            else {
                losses++;
                Console.WriteLine("You lose! Computer's {0} defeats your {1}!", ConvertChoiceToWord(computerChoice), ConvertChoiceToWord(userChoice));
            }
        }

        private string ConvertChoiceToWord(string choice)
        {
            if (choice == "r")
            {
                return "rock";
            }
            else if (choice == "p")
            {
                return "paper";
            }
            else
            {
                return "scissors";
            }
        }

        private string GetComputerChoice()
        {
            int choice = rng.Next(1, 4);

            if (choice == 1)
            {
                return "r";
            }
            else if (choice == 2)
            {
                return "p";
            }
            else
            {
                return "s";
            }
        }

        private string PromptUser()
        {
            while (true)
            {
                Console.Write("Enter your choice of (r)ock, (p)aper, (s)cissors, or (q)uit: ");
                string choice = Console.ReadLine();

                if (choice == "r" || choice == "p" || choice == "s" || choice == "q")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose again.");
                }
            }
        }
    }
}
