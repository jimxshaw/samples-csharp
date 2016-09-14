using System;

namespace ObserverDemo
{
    public class Logger
    {
        public void AfterDoSomethingWith(object sender, string data)
        {
            Console.WriteLine($"Logger: logging {data.ToUpper()}");
        }

        public void AfterDoMore(object sender, Tuple<string, string> data)
        {
            Console.WriteLine($"Logger: logging appended {data.Item2.ToUpper()}");
        }


    }
}
