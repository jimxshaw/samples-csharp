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
            string userChoise;
            userChoise = PromptUser();
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
