namespace ObserverDemo.Observers
{
    public class UserInterface
    {
        public readonly Interfaces.IObserver<string> AfterDoSomethingWith;

        public UserInterface()
        {
            AfterDoSomethingWith = new NotificationSink<string>((sender, data) => AfterDoSomethingWithHandler(sender, data));
        }

        public void AfterDoSomethingWithHandler(object sender, string data)
        {

        }
    }
}
