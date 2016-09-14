using System;

namespace ObserverDemo
{
    public class NotificationSink<T> : Interfaces.IObserver<T>
    {
        private Action<object, T> _action;

        public NotificationSink(Action<object, T> action)
        {
            _action = action;
        }

        public void Update(object sender, T data)
        {
            _action(sender, data);
        }
    }
}
