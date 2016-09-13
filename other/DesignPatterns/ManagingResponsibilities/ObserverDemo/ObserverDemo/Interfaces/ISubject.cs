namespace ObserverDemo.Interfaces
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void AfterDoSomething(string data);
        void AfterDoMore(string completeData, string appendedData);
    }
}
