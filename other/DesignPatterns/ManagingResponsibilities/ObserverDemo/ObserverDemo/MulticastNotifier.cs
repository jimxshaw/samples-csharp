using ObserverDemo.Interfaces;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class MulticastNotifier<T>
    {
        private IList<IObserver<T>> _invocationList;

        private MulticastNotifier(IObserver<T> observer)
        {
            _invocationList = new List<IObserver<T>>();
            _invocationList.Add(observer);
        }

        private MulticastNotifier(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            _invocationList = new List<IObserver<T>>(notifier._invocationList);
            _invocationList.Add(observer);
        }

        public void Notify(object sender, T data)
        {
            foreach (IObserver<T> observer in _invocationList)
            {
                observer.Update(sender, data);
            }
        }

        public static MulticastNotifier<T> operator +(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            if (notifier == null)
            {
                return new MulticastNotifier<T>(observer);
            }

            return new MulticastNotifier<T>(notifier, observer);
        }
    }
}
