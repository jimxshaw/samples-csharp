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
            //Messenger myMessage = new Messenger();
            //myMessage.SayHello();

            var a = 1;

            MyMethod(a);

            Console.WriteLine(a);

            Console.ReadLine();
        }

        public static void MyMethod(int a)
        {
            a += 2;
        }
    }




}
