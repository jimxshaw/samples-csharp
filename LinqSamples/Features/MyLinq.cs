using System.Collections.Generic;

namespace Features
{
    public static class MyLinq
    {
        // The this keyword in front of the first parameter signals that this method is an extension method.
        // We could call Count either using the usual static way with MyLinq.Count(sequence) or, in any place 
        // we have IEnumerble<T>, simply invoke .Count(sequence). We can invoke with myArray.Count() or 
        // myList.Count() or with any other IEnumerable collection.  
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int counter = 0;
            foreach (var item in sequence)
            {
                counter += 1;
            }

            return counter;
        }
    }
}
