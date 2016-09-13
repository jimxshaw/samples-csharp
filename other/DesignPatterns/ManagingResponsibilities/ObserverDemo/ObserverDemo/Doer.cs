using ObserverDemo.Interfaces;
using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class Doer : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        private string _data = string.Empty;

        public void DoSomethingWith(string data)
        {
            Console.WriteLine($"Doing something with {data}");
            _data = data;
            AfterDoSomething(_data);
        }

        public void DoMore(string appendData)
        {
            _data += appendData;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void AfterDoSomething(string data)
        {
            foreach (var observer in _observers)
            {
                observer.AfterDoSomethingWith(this, data);
            }
        }

        public void AfterDoMore(string completeData, string appendedData)
        {
            foreach (var observer in _observers)
            {
                observer.AfterDoMore(this, completeData, appendedData);
            }
        }
    }
}
