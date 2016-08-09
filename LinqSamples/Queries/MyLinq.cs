using System;
using System.Collections.Generic;

namespace Queries
{
    public static class MyLinq
    {

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                // The predicate Func takes in T and asks should this type be in our result 
                // collection, true or false, based on its internal implementation.
                if (predicate(item))
                {
                    // Yield return gives us the behavior known as deferred execution. It means LINQ will do 
                    // the least amount of work it can get away with. 
                    yield return item;
                }
            }
        }
    }
}
