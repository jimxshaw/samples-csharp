using NHibernate.Mapping.ByCode;
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

        public virtual void SetPassword(string password)
        {
            
        }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            // Tell NHibernate which table this data originates.
            Table("users");

            // Specifies which property is the primary key and then
            // states that the key is auto-generated.
            Id(x => x.Id, x => x.Generator(Generators.Identity));

            // Specifies that the username and email cannot be null.
            Property(x => x.Username, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));

            // Lambda expressions with more than one method has
            // to be surrounded by curly braces.
            Property(x => x.PasswordHash, x =>
            {
                x.Column("password_hash");
                x.NotNullable(true);
            });
        }
    }
}