namespace EFCodeFirstExistingDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedCategoriesTable : DbMigration
    {
        public override void Up()
        {
            //Sometimes table values need to be preserved so
            //it's best to create a new holdings table to hold 
            //said values. Afterwards, the specified table can
            //be dropped. 

            CreateTable(
                "dbo._Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO _Categories(Name) SELECT Name FROM Categories");

            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Categories(Name) SELECT Name FROM _Categories");

            DropTable("dbo._Categories");

        }
    }
}
