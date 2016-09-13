using System;

namespace ObserverDemo
{
    public class UserInterface : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Hello user, something has been updated!");
        }
    }
}
