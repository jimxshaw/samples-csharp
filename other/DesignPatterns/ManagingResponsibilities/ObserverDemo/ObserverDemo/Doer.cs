using System;

namespace ObserverDemo
{
    public class Doer
    {
        public MulticastNotifier<string> AfterDoSomethingWith;

        public MulticastNotifier<Tuple<string, string>> AfterDoMore;

        private string _data = string.Empty;

        public void DoSomethingWith(string data)
        {
            _data = data;
            OnAfterDoSomethingWith(_data);
        }

        public void DoMore(string appendData)
        {
            _data += appendData;
            OnAfterDoMore(_data, appendData);
        }

        private void OnAfterDoSomethingWith(string data)
        {
            if (AfterDoSomethingWith != null)
            {
                AfterDoSomethingWith.Notify(this, data);
            }
        }

        private void OnAfterDoMore(string completeData, string appendedData)
        {
            if (AfterDoMore != null)
            {
                AfterDoMore.Notify(this, Tuple.Create(completeData, appendedData));
            }
        }
    }
}
