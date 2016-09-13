using ObserverDemo.Interfaces;
using System;

namespace ObserverDemo.Observers
{
    public class UserInterface : IObserver
    {
        public void Update()
        {
            Console.WriteLine("UI: Hello user, something has been updated!");
        }
    }
}
