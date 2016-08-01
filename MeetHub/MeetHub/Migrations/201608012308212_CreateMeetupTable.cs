namespace MeetHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMeetupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Category_Id = c.Byte(),
                        Group_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Group_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetups", "Group_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetups", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Meetups", new[] { "Group_Id" });
            DropIndex("dbo.Meetups", new[] { "Category_Id" });
            DropTable("dbo.Meetups");
            DropTable("dbo.Categories");
        }
    }
}
