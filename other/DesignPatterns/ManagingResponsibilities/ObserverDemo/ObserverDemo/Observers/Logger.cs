using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class Logger : IObserver
    {
        public void AfterDoSomethingWith(ISubject sender, string data)
        {
            Console.WriteLine($"Logger: logging {data.ToUpper()}");
        }

        public void AfterDoMore(ISubject sender, string completeData, string appendedData)
        {

        }
    }
}
