namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTriMonthlyToQuarterly1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
