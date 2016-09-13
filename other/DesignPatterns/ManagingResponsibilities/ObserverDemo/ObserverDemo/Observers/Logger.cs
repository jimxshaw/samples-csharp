using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class Logger : IObserver
    {
        public void Update(ISubject sender, string data)
        {
            Console.WriteLine($"Logger: logging {data.ToUpper()}");
        }
    }
}
