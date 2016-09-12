using System.Data.Common;

namespace AbstractFactory
{
    public abstract class Database
    {
        // DbConnection and DbCommand are objects that the rest of the appliction will  
        // work with but they themselves don't expose the database technology.
        public virtual DbConnection Connection { get; set; }
        public virtual DbCommand Command { get; set; }
    }
}
