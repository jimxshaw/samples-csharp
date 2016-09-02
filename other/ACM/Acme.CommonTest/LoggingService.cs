using System;
using System.Collections.Generic;

namespace Acme.CommonTest
{
    public static class LoggingService
    {
        public static void WriteToFile(List<object> changedItems)
        {
            foreach (var item in changedItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
