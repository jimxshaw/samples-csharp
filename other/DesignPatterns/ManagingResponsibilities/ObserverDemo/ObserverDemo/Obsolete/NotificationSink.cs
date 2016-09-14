namespace ObserverDemo.Obsolete
{
    // After adding events and EventHandler<T> to Doer class, this class is 
    // no longer needed. 

    //public class NotificationSink<T> : Interfaces.IObserver<T>
    //{
    //    private Action<object, T> _action;

    //    public NotificationSink(Action<object, T> action)
    //    {
    //        _action = action;
    //    }

    //    public void Update(object sender, T data)
    //    {
    //        _action(sender, data);
    //    }
    //}
}
