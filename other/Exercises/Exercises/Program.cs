using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(KeyOfC("ABCDEFG"));
            //GenderOfCelebrity2(celebArray);
            //StringsWithoutVowels2();
            //DivisibleByThreeCount2(1000);
            //SingleDoubleTriple(20);
            Checkerboard(8);

            Console.ReadLine();
        }

        public static string KeyOfC(string original)
        {
            // Take a string of "ABCDEFG" and turn it into the
            // key of C, which is "CDEFGAB".
            string originalA = original.Substring(0, 2);
            string originalB = original.Substring(2);

            return originalB + originalA;
        }

        public static void GenderOfCelebrity1()
        {
            // Given an array of celebrities and genders beside their names,
            // count of number of males and females and print out the final
            // counts of each.

            string[] celebArray =
            {
                "Beyonce (f)",
                "Tom Cruise (m)",
                "Taylor Swift (f)",
                "Tom Brady (m)",
                "John Lennon (m)",
                "Wall-E"
            };

            int male = 0;
            int female = 0;
            int unknown = 0;

            foreach (var celeb in celebArray)
            {
                switch (celeb.Substring(celeb.Length - 2, 1))
                {
                    case "m":
                        male++;
                        break;
                    case "f":
                        female++;
                        break;
                    default:
                        unknown++;
                        break;
                }
            }

            Console.WriteLine("Gender of Celebrities");
            Console.WriteLine("Number of males: {0}", male);
            Console.WriteLine("Number of females: {0}", female);
            Console.WriteLine("Number of unknowns: {0}", unknown);
        }

        public static void GenderOfCelebrity2()
        {
            // Given an array of celebrities and genders beside their names,
            // count of number of males and females and print out the final
            // counts of each.

            string[] celebArray =
            {
                "Beyonce (f)",
                "Tom Cruise (m)",
                "Taylor Swift (f)",
                "Tom Brady (m)",
                "John Lennon (m)",
                "Wall-E"
            };

            int male = 0;
            int female = 0;
            int unknown = 0;

            for (var i = 0; i < celebArray.Length; i++)
            {
                if (celebArray[i].Contains("(m)"))
                {
                    male++;
                }
                else if (celebArray[i].Contains("(f)"))
                {
                    female++;
                }
                else
                {
                    unknown++;
                }
            }

            Console.WriteLine("Gender of Celebrities");
            Console.WriteLine("Number of males: {0}", male);
            Console.WriteLine("Number of females: {0}", female);
            Console.WriteLine("Number of unknowns: {0}", unknown);
        }

        public static void StringsWithoutVowels1()
        {
            // Given an array of strings, remove the vowels
            // in each string and then print out the result.

            string[] instruments =
            {
                "double bass",
                "viola",
                "cello",
                "violin",
                "guitar"
            };

            // Declare a new array to store the strings without vowels.
            string[] instrumentsWithoutVowels = new string[5];

            // Loop through the instruments in the original array.
            for (var i = 0; i < instruments.Length; i++)
            {
                // Declare a new string to hold just the consonants.
                string newString = "";
                // Declare a new variable to improve readability.
                string instrumentInArray = instruments[i];

                // Loop through each character in a particular string.
                for (var j = 0; j < instrumentInArray.Length; j++)
                {
                    // Must convert each char type to string type and
                    // force it to be lowercase.
                    switch (instrumentInArray[j].ToString().ToLower())
                    {
                        // If the letter is a vowel, do nothing.
                        case "a":
                        case "e":
                        case "i":
                        case "o":
                        case "u":
                            break;
                        default:
                            // Consonants get added to the new string.
                            newString += instrumentInArray[j];
                            break;
                    }
                }

                // Add the new string to the new array.
                instrumentsWithoutVowels[i] = newString;
            }

            foreach (var item in instrumentsWithoutVowels)
            {
                Console.WriteLine(item);
            }
        }

        public static void StringsWithoutVowels2()
        {
            string[] vowels =
            {
                "a",
                "e",
                "i",
                "o",
                "u"
            };

            string[] instruments =
            {
                "double bass",
                "viola",
                "cello",
                "violin",
                "guitar"
            };

            for (var i = 0; i < instruments.Length; i++)
            {
                string instrument = instruments[i];

                for (var j = 0; j < vowels.Length; j++)
                {
                    instrument = instrument.Replace(vowels[j], "");
                }

                Console.WriteLine(instrument);
            }
        }

        public static void DivisibleByThreeCount1(int number)
        {
            int count = 0;
            int incrementor = 1;

            while (incrementor <= number)
            {
                if (incrementor % 3 == 0)
                {
                    count++;
                }

                incrementor++;
            }

            Console.WriteLine(count);
        }

        public static void DivisibleByThreeCount2(int number)
        {
            int count = 0;

            for (var i = 1; i <= number; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public static void SingleDoubleTriple(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                Console.WriteLine($"{i} {i * 2} {i * 3}");
            }
        }

        public static void Checkerboard(int number)
        {
            string checkerboard = "";

            for (var row = 0; row < number; row++)
            {
                for (var column = 0; column < number; column++)
                {
                    if ((row + column) % 2 == 0)
                    {
                        checkerboard += "  ";
                    }
                    else
                    {
                        checkerboard += "#";
                    }
                }
                checkerboard += "\n";
            }

            Console.WriteLine(checkerboard);
        }
    }
}
