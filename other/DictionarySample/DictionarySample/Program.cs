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
            /*
                A dictionary is comprised of buckets, which are similar to linked lists. Each bucket 
                holds a location in memory. Whenever a key-value pair is added to a dictionary, some 
                underlying algorithm determines the index of the key and specifies which bucket the key 
                is contained. Key-value pairs are generally distributed evenly among the buckets but if there
                are more pairs than buckets then a bucket will have more than one item.
                If the bucket has more than one item then the algorith checks the input key with the
                keys in the bucket to get the right key.

                Dictionaries are good for performance because:
                -- Algorithm to find a bucket is quick
                -- Not many elements to search in a bucket
                -- A bucket is like a linked list, which inherently is good for performance
            */

            var presidents = new Dictionary<string, President>(new UncasedStringEqualityComparer())
            {
                {"AL", new President("Abraham Lincoln", 1860)},
                {"WW", new President("Woodrow Wilson", 1912)},
                {"FDR", new President("Franklin Roosevelt", 1932)}
            };

            //President president;
            //bool found = presidents.TryGetValue("JFK", out president);

            //if (found)
            //{
            //    Console.WriteLine("Value is: " + president.ToString() + "\r\n");
            //}
            //else
            //{
            //    Console.WriteLine("Value not in dictionary");
            //}

            //presidents["AL"] = new President("Abe Lincoln", 1860);

            //foreach (var president in presidents)
            //{
            //    Console.WriteLine(president.Value);
            //}

            Console.WriteLine(presidents["ww"]);

            Console.ReadLine();
        }
        
    }

    class UncasedStringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }

        // If two objects are equal then they must return
        // the same hash code. This is so that dictionaries
        // can search through the right bucket for the search key.
        public int GetHashCode(string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}
