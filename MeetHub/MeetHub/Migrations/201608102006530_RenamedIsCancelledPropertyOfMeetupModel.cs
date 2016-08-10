namespace MeetHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedIsCancelledPropertyOfMeetupModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "IsCancelled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Meetups", "IsCanceled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meetups", "IsCanceled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Meetups", "IsCancelled");
        }
    }
}
