using ObserverDemo.Observers;
using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();
            doer.Attach(new Logger());
            doer.Attach(new UserInterface());

            doer.DoSomethingWith("input data");
            doer.DoMore("additional data processing");

            Console.ReadLine();
        }
    }
}
