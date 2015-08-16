using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsAndFormattingStrings
{
    class Program
    {
        // We can do a single line coment with two slashes

        /* slash + asterisk does multiple
         * line comments.  You must end with an 
         * asterisk in a slash to stop */

        /// <summary>
        /// Three slashes before a method or class will do a documentation comment.
        /// We can generate help documentation with this
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Let's demo formatting strings.  Press enter to begin...");
            Console.ReadLine();
            Console.Clear();

            DemoSubstitutionStrings();
            LeftAlign();
            RightAlign();
            FormatNumericalData();
            StringDotFormat();
        }

        static void DemoSubstitutionStrings()
        {
            Console.WriteLine("Substitution strings are easier to read than concatenation");
            Console.WriteLine("----------------------------------------------------------");

            // Get some data
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            Console.Write("Enter your favorite color: ");
            string favoriteColor = Console.ReadLine();

            // Substitution strings are in curly braces, they always start with 0
            // Each substitution string is replaced by the values following the string
            Console.WriteLine("Hello {0}! Your favorite color is {1}.\nI like the name {0}.\n",
              userName, favoriteColor);

            // We can pass literals or variables
            Console.WriteLine("My favorite number is {0}.", 0);

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static void LeftAlign()
        {
            Console.WriteLine("Put a comma and a negative number to left align. ex: {0,-15}");
            Console.WriteLine("------------------------------------------------------------");

            string lineOutputFormat = "{0,-15} {1,-2} {2,-5}";
            Console.WriteLine(lineOutputFormat, "Jon Snow", "ME", "44444");
            Console.WriteLine(lineOutputFormat, "Oberyn Martell", "TX", "12345");
            Console.WriteLine(lineOutputFormat, "Jorah Mormont", "SC", "54321");

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static void RightAlign()
        {
            Console.WriteLine("Put a comma and a positive number to right align. ex: {1,9}");
            Console.WriteLine("-----------------------------------------------------------");

            /* Two things:
             * 1. We can store a format in a string for later
             * 2. We can use the : and a format code to do things like currency format
             */

            string lineOutputFormat = "{0,-15} {1,9:C}";
            Console.WriteLine(lineOutputFormat, "A12345678", 4728.55);
            Console.WriteLine(lineOutputFormat, "A392848293", 14.33);

            // this one will overflow, watch what happens
            Console.WriteLine(lineOutputFormat, "A20859329", 1232706.00);

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();

        }

        /* here are some standard number formats
         * 
         * A list of standard codes is found here: 
         * http://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx
         */
        static void FormatNumericalData()
        {
            Console.WriteLine("The value 12345 in various formats:\n");
            Console.WriteLine("c format: {0:c}", 12345);
            Console.WriteLine("d9 format: {0:d9}", 12345);
            Console.WriteLine("f3 format: {0:f3}", 12345);
            Console.WriteLine("n format: {0:n}", 12345);

            Console.WriteLine("\n");

            // Notice that upper- or lowercasing for hex
            // determines if letters are upper- or lowercase.
            Console.WriteLine("E format: {0:E}", 12345);
            Console.WriteLine("e format: {0:e}", 12345);

            Console.WriteLine("For hex we will use 99999 to get some letters.");
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);


            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static void StringDotFormat()
        {
            // string.Format() allows for substitution strings as well.  
            //It returns a string we can store for later

            string totalLine = string.Format("Total: {0:c}", 98.43);
            Console.WriteLine(totalLine);

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
