using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class Logger : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Logger: update has been written and logged.");
        }
    }
}
