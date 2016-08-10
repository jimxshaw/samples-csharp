namespace MeetHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledPropertyToMeetupModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "IsCanceled");
        }
    }
}
