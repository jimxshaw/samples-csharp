using System;

namespace ObserverDemo
{
    public class Doer : ISubject
    {
        public void DoSomethingWith(string data)
        {
            Console.WriteLine($"Do something with {data}");
            Notify();
        }

        public void Attach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
