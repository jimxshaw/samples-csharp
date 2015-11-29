namespace EFCodeFirstExistingDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTitleToNameInCoursesTable : DbMigration
    {
        //Generally, whatever is done to the Up() method ought to be in reverse
        //when dealing with the Down() method.

        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            Sql("UPDATE Courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
            
            
            //RenameColumn("dbo.Courses", "Title", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            Sql("UPDATE Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");


            //RenameColumn("dbo.Courses", "Name", "Title");
        }
    }
}
