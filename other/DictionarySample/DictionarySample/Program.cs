using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new Dictionary<string, President>()
            {
                {"AL", new President("Abraham Lincoln", 1860)},
                {"WW", new President("Woodrow Wilson", 1912)},
                {"FDR", new President("Franklin Roosevelt", 1932)}
            };

            foreach (var president in presidents)
            {
                Console.WriteLine(president);
            }

            Console.ReadLine();
        }
    }
}
