using FluentMigrator;

namespace SimpleBlogMVC.Migrations
{
    [Migration(1)]
    public class _001_UsersAndRoles : Migration
    {
        // Up method is invoked when FluentMigrator decides the database needs to
        // migrate up where you need to do your modifications to that database.
        // You can roll up to a full-fledged database.
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsString(256)
                .WithColumn("password_hash").AsString(128);
        }

        // Down method is invoked when you roll back your changes to the database.
        // You can roll down to nothing essentially if, for example, a deployment
        // fails. 
        public override void Down()
        {
            Delete.Table("users");
        }
    }
}