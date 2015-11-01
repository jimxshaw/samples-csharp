using System.Net;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlogMVC.Models;

namespace SimpleBlogMVC
{
    public static class Database
    {
        // The session factory will be shared by various class methods so
        // a variable should be created to simplify things.
        private static ISessionFactory _sessionFactory;

        private const string SessionKey = "SimpleBlogMVC.Database.SessionKey";

        public static ISession Session
        {
            get { return (ISession) HttpContext.Current.Items[SessionKey]; }
        }

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
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            // Create session factory.
            _sessionFactory = config.BuildSessionFactory();
        }

        // OpenSession() will be invoked at the beginning of every request by
        // opening a session.
        public static void OpenSession()
        {
            // Essentially opens a connection to a database.
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        // CloseSession() will be invoked at the end of every request by
        // closing the session.
        public static void CloseSession()
        {
            // Give an object, of type ISession, at the session key in items.
            ISession session = HttpContext.Current.Items[SessionKey] as ISession;

            // Essentially closes a connection to a database.
            if (session != null)
            {
                session.Close();
            }

            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}