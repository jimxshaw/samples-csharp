using ObserverDemo.Interfaces;
using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class Doer : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public string Data { get; private set; }

        public void DoSomethingWith(string data)
        {
            Console.WriteLine($"Doing something with {data}");
            Data = data;
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
