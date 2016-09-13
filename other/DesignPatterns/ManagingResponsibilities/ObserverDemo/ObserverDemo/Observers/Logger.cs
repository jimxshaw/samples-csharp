using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class Logger : IObserver
    {
        public void Update(ISubject sender)
        {
            Console.WriteLine($"Logger: logging {sender.Data.ToUpper()}");
        }
    }
}
