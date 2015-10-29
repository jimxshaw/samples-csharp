using System.Data;
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
                .WithColumn("email").AsCustom("VARCHAR(256)")
                .WithColumn("password_hash").AsString(128);

            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);

            // Pivot table that connects users and roles.
            Create.Table("role_users")
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);
        }

        // Down method is invoked when you roll back your changes to the database.
        // You can roll down to nothing essentially if, for example, a deployment
        // fails. 
        public override void Down()
        {
            // Pivot table MUST be deleted first so it's placed here on top.
            Delete.Table("roles_users");
            Delete.Table("roles");
            Delete.Table("users");
            
        }
    }
}