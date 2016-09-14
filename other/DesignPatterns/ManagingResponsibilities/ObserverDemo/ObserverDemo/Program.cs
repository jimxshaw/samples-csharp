using ObserverDemo.Observers;
using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();

            UserInterface userInterface = new UserInterface();
            Logger logger = new Logger();

            doer.AfterDoSomethingWith += userInterface.AfterDoSomethingWith;
            doer.AfterDoSomethingWith += logger.AfterDoSomethingWith;

            doer.AfterDoMore += logger.AfterDoMore;

            doer.DoSomethingWith("input data");
            doer.DoMore("additional data processing");

            Console.ReadLine();
        }
    }
}
