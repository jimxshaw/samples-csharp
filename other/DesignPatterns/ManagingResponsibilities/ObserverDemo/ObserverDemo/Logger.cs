using System;

namespace ObserverDemo
{
    public class Logger : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Updated has been written and logged.");
        }
    }
}
