namespace ObserverDemo.Interfaces
{
    public interface IObserver<T>
    {
        void Update(object sender, T data);
    }
}
