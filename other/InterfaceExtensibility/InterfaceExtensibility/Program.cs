using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensibility
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
    }

    public class DbMigrator
    {
        private readonly ILogger _logger;

        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.LogInfo("Migration started at " + DateTime.Now);

            // Details of migrating the database

            _logger.LogInfo("Migration finished at " + DateTime.Now);

        }
    }

    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        private void Log(string message, string messageType)
        {
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(messageType + ": " + message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new FileLogger("C:\\Temp\\log.txt"));
            dbMigrator.Migrate();
        }
    }
}
