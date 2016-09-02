using System;
using System.Collections.Generic;

namespace Acme.Common
{
    public static class LoggingService
    {
        // By passing in an interface, ILoggable, instead of a concrete type 
        // it allows us to access any items through said interface.
        public static void WriteToFile(List<ILoggable> changedItems)
        {
            foreach (var item in changedItems)
            {
                Console.WriteLine(item.Log());
            }
        }
    }
}
