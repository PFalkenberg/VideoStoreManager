namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'ba3fd369-c117-4e1b-b72d-82f684b1d977', N'guest@domain.com', 0, N'ADji4u1HVdu7iLZSk2sk7dwf5peZbSfcfuD+CyTZKURMkwxChQ6S8C8GCYvrGlq/yA==', N'83369b91-782c-4aa3-9be7-48c7764a8c31', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com', N'555-543-555')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'da9c6a1b-ca6d-477d-9cc4-e31e492e8b26', N'admin@domain.com', 0, N'ABlB7jXDlp6Vj0MZh9mHFXsvbY2Z6jG/5flsQOJEwG1xEmgIhzj0DefiYDdybWea5Q==', N'dc02b511-e0cd-4483-bec0-c74379ac5aad', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com', N'444-444-4444')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a143a6c6-5334-477c-9081-b752a2047642', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'da9c6a1b-ca6d-477d-9cc4-e31e492e8b26', N'a143a6c6-5334-477c-9081-b752a2047642')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
