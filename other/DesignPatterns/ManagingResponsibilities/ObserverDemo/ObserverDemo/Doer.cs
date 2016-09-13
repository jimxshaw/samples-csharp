using System;

namespace ObserverDemo
{
    public class Doer : ISubject
    {
        public void DoSomethingWith(string data)
        {
            Console.WriteLine($"Do something with {data}");
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
