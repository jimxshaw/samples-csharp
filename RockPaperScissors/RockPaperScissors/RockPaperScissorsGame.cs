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
                Console.WriteLine("The computer picked {0}", ConvertChoiceToWord(computerChoice));
                userChoice = PromptUser();
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
