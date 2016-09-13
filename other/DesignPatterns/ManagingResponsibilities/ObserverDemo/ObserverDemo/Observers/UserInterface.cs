using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class UserInterface : IObserver
    {
        public void Update(ISubject sender)
        {
            Console.WriteLine($"UI: Hello user, take a look at {sender.Data.ToUpper()}");
        }

    }
}
