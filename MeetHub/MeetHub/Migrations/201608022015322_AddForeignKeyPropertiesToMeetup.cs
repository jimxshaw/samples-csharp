namespace MeetHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToMeetup : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meetups", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Meetups", name: "Group_Id", newName: "GroupId");
            RenameIndex(table: "dbo.Meetups", name: "IX_Group_Id", newName: "IX_GroupId");
            RenameIndex(table: "dbo.Meetups", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meetups", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Meetups", name: "IX_GroupId", newName: "IX_Group_Id");
            RenameColumn(table: "dbo.Meetups", name: "GroupId", newName: "Group_Id");
            RenameColumn(table: "dbo.Meetups", name: "CategoryId", newName: "Category_Id");
        }
    }
}
