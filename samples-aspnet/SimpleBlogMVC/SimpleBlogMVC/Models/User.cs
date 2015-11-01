using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlogMVC.Models
{
    public class User
    {
        // Every single class that you want NHibernate to map to
        // must have ALL of its members be listed as virtual.
        // NHibernate creates proxy classes at runtime and needs 
        // to override developer implemented class members. 
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }
    }

    public class UserMap : ClassMapping<User>
    {
        
    }
}