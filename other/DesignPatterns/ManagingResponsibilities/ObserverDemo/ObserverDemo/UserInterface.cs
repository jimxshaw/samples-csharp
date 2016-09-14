using System;

namespace ObserverDemo
{
    public class UserInterface
    {
        public void AfterDoSomethingWith(object sender, string data)
        {
            Console.WriteLine($"UI: updating {data.ToUpper()}");
        }
    }
}
