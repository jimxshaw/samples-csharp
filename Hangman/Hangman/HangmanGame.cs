using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class HangmanGame
    {
        private bool _keepPlaying;
        private int _guessesLeft;
        private string _answer;
        private int _lettersFound;

        private string[] _guessedLetters;
        private int _guessedLettersIndex;

        private string[] _wordDisplay;

        public void Play()
        {
            Setup();

            while (_keepPlaying)
            {
                DisplayPuzzle();
                PromptUser();
            }

            DisplayResult();
        }

        private void PromptUser()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Guess a letter or the entire word: ");
                validInput = ParseInput(Console.ReadLine().ToUpper());
            }

            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
        }

        private bool ParseInput(string input)
        {
            if (input.Length > 1)
            {
                if (input == _answer)
                {
                    Console.WriteLine("You guessed correctly!");
                    _keepPlaying = false;
                    return true;
                }
                Console.WriteLine("Wrong answer!");
                _guessesLeft--;
            }
            else {
                if (_guessedLetters.Contains(input))
                {
                    Console.WriteLine("You already guessed {0}", input);
                    return false;
                }
                bool foundLetterAtLeastOnce = false;
                for (int i = 0; i < _answer.Length; i++)
                {
                    if (input == _answer[i].ToString())
                    {
                        foundLetterAtLeastOnce = true;
                        _lettersFound++;
                        _wordDisplay[i] = input;
                    }
                }
                if (foundLetterAtLeastOnce)
                {
                    Console.WriteLine("Good guess!");
                    if (_lettersFound == _answer.Length)
                    {
                        _keepPlaying = false;
                    }
                }
                else {
                    Console.WriteLine("That letter was not found.");
                    _guessesLeft--;
                }
            }
            _guessedLetters[_guessedLettersIndex] = input;
            _guessedLettersIndex++;

            if (_guessesLeft == 0)
            {
                _keepPlaying = false;
            }

            return true;
        }

        private void DisplayResult()
        {
            if (_guessesLeft > 0)
            {
                Console.WriteLine("You win! The word was: {0}", _answer);
            }
            else
            {
                Console.WriteLine("You lose! The word was: {0}", _answer);
            }
        }

        private void DisplayPuzzle()
        {
            Console.WriteLine("\nPuzzle: ");
            for (int i = 0; i < _wordDisplay.Length; i++)
            {
                Console.Write("{0} ", _wordDisplay[i]);
            }
            Console.WriteLine("\n\nYou have {0} guesses left.\n", _guessesLeft);
        }

        private void Setup()
        {
            _guessesLeft = 5;
            _keepPlaying = true;
            _guessedLetters = new String[26];
            _guessedLettersIndex = 0;
            GetWordFromPlayer();
            CreateWordDisplay();
        }

        private void CreateWordDisplay()
        {
            _wordDisplay = new String[_answer.Length];
            for (int i = 0; i < _wordDisplay.Length; i++)
            {
                _wordDisplay[i] = "_";
            }
        }

        private void GetWordFromPlayer()
        {
            Console.Write("Enter a word: ");
            _answer = Console.ReadLine().ToUpper();
            Console.Clear();
        }
    }
}
