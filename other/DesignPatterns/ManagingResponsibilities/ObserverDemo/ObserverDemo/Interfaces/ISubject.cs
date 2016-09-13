namespace ObserverDemo.Interfaces
{
    public interface ISubject
    {
        string Data { get; }
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}
