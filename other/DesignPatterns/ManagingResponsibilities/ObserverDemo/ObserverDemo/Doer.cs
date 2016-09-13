using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class Doer : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void DoSomethingWith(string data)
        {
            Console.WriteLine($"Do something with {data}");
            Notify();
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }
}
