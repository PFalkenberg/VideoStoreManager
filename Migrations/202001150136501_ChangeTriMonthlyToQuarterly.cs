namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTriMonthlyToQuarterly : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Tri-Monthly' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
