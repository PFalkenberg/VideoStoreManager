namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdToMovieClass1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
