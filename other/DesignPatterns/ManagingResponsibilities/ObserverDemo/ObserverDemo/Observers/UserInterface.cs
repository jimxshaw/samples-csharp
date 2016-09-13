using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class UserInterface : IObserver
    {
        public void AfterDoSomethingWith(ISubject sender, string data)
        {
            Console.WriteLine($"UI: Hello user, take a look at {data.ToUpper()}");
        }

        public void AfterDoMore(ISubject sender, string completeData, string appendedData)
        {

        }
    }
}
