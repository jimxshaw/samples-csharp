using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookie();

            // name is the dicionary key, James is 
            // the dictionary value.
            cookie["name"] = "James";

            Console.WriteLine(cookie["name"]);

            Console.ReadLine();
        }
    }
}
