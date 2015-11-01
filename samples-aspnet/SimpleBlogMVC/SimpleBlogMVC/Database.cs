using NHibernate.Cfg;

namespace SimpleBlogMVC
{
    public static class Database
    {
        // Configure() will be invoked at application startup.
        // This will configure NHibernate.
        public static void Configure()
        {
            Configuration config = new Configuration();

            // Configure the connection string.
            // If parameterless Configure() method is used then it 
            // will look inside Web.config for a special section that's 
            // written by the developer and use that as the paramter for 
            // Configure().
            config.Configure();

            // Add our mappings.

            // Create session factory.
        }

        // OpenSession() will be invoked at the beginning of every request by
        // opening a session.
        public static void OpenSession()
        {
            
        }

        // CloseSession() will be invoked at the end of every request by
        // closing the session.
        public static void CloseSession()
        {
            
        }
    }
}