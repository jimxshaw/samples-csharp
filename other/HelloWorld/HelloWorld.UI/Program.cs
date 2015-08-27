using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger myMessage = new Messenger();
            myMessage.SayHello();

            Console.ReadLine();
        }
    }
}
