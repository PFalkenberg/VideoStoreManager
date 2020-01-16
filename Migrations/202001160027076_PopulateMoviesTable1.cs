namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock, GenreId) VALUES ('The Hangover', '20090602 12:00:00 AM', 5, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock, GenreId) VALUES ('Die Hard', '19880715 12:00:00 AM', 3, 2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock, GenreId) VALUES ('The Terminator', '19841026 12:00:00 AM', 4, 2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock, GenreId) VALUES ('Toy Story', '19951122 12:00:00 AM', 6, 3)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock, GenreId) VALUES ('Titanic', '19971219 12:00:00 AM', 2, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
