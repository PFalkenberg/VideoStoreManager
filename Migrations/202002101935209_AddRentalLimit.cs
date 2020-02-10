namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalLimit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ActiveRentals", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ActiveRentals");
        }
    }
}
