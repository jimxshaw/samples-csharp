using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();

            doer.DoSomethingWith("my data");

            Console.ReadLine();
        }
    }
}
