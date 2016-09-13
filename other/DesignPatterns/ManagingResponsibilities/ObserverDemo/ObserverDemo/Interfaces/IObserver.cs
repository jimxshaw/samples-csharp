namespace ObserverDemo.Interfaces
{
    public interface IObserver
    {
        void Update(ISubject sender);
    }
}
