using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LoggingInterface
{
    static class ILoggerFactory
    {
        private static ILogger _myLogger;

        public static ILogger GetLogger()
        {
            if (_myLogger == null)
            {
                string logType = ConfigurationManager.AppSettings["logtype"];

                if (logType == "C")
                {
                    _myLogger = new ConsoleLogger();
                }
                else if (logType == "F")
                {
                    _myLogger = new FileLogger();
                }
            }
            return _myLogger;
        }
    }
}
