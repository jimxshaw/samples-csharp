namespace MeetHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Technology')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Business')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Health')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Law')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (5, 'Politics')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (6, 'Food')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (7, 'Entertainment')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (8, 'Sports')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (9, 'Fashion')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (10, 'Culture')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (11, 'Family')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (12, 'Other')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id in (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)");
        }
    }
}
