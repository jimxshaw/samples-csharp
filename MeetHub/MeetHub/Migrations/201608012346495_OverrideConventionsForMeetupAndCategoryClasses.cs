namespace MeetHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForMeetupAndCategoryClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetups", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Meetups", "Group_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Meetups", new[] { "Category_Id" });
            DropIndex("dbo.Meetups", new[] { "Group_Id" });
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Meetups", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Meetups", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Meetups", "Category_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Meetups", "Group_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Meetups", "Category_Id");
            CreateIndex("dbo.Meetups", "Group_Id");
            AddForeignKey("dbo.Meetups", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Meetups", "Group_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetups", "Group_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetups", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Meetups", new[] { "Group_Id" });
            DropIndex("dbo.Meetups", new[] { "Category_Id" });
            AlterColumn("dbo.Meetups", "Group_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Meetups", "Category_Id", c => c.Byte());
            AlterColumn("dbo.Meetups", "Title", c => c.String());
            AlterColumn("dbo.Meetups", "Venue", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.Meetups", "Group_Id");
            CreateIndex("dbo.Meetups", "Category_Id");
            AddForeignKey("dbo.Meetups", "Group_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Meetups", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
