namespace ObserverDemo.Obsolete
{
    public interface IObserver<T>
    {
        // This interface is no longer need as it's replaced by events 
        // in the Doer class.

        //void Update(object sender, T data);
    }
}
