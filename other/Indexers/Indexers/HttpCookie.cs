using System;
using System.Collections.Generic;

namespace Indexers
{
    public class HttpCookie
    {
        private readonly Dictionary<string, string> _dictionary;
        public DateTime Expiry { get; set; }

        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        // Indexers have no names. They must utilize this
        // naming convention.
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }

        // Without indexers, the below methods would have to
        // be created. There's nothing wrong with using them.
        // Indexers are simply more efficient.
        /*
            public void SetItem(string key, string value)
            {
            
            }

            public void GetItem(string key)
            {
            
            }
        */
    }
}