using System;

namespace ObserverDemo.Observers
{
    public class Logger
    {
        public readonly Interfaces.IObserver<string> AfterDoSomethingWith;

        public readonly Interfaces.IObserver<Tuple<string, string>> AfterDoMore;

        public Logger()
        {
            AfterDoSomethingWith = new NotificationSink<string>((sender, data) => AfterDoSomethingWithHandler(sender, data));

            AfterDoMore = new NotificationSink<Tuple<string, string>>((sender, data) => AfterDoMoreHandler(sender, data));
        }

        public void AfterDoSomethingWithHandler(object sender, string data)
        {
            Console.WriteLine($"Logger: logging {data.ToUpper()}");
        }

        public void AfterDoMoreHandler(object sender, Tuple<string, string> data)
        {
            Console.WriteLine($"Logger: logging appended {data.Item2.ToUpper()}");
        }


    }
}
