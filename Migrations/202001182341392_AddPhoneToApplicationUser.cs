namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "UserPhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserPhoneNumber", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
