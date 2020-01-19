namespace VideoStoreManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'406eda9d-93ee-4a19-83d8-bcbd76aa00d4', N'admin@domain.com', 0, N'ALl1Qr1RHgBOzofYNYSzk4JlMwQ/JEvXDzw36T55KLWe3+ujy041MfhG3+NnHY0Zzw==', N'2cfa763d-2751-46a6-9260-6671b6d240b5', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ca100cf5-ea7a-4eb7-b7c6-d0f1fea70bf8', N'guest@domain.com', 0, N'AFm68swz9bw9lvlYtkiVIzetjc+GTBus0qJ7orcVzZK00xkKtVDZckurlybfux05Bw==', N'da94ed40-cdc5-40b8-88e3-6d146a5a5153', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'61cc5661-c7e8-40ae-ab0b-1e7b51317c75', N'CanManageMovies')


                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'406eda9d-93ee-4a19-83d8-bcbd76aa00d4', N'61cc5661-c7e8-40ae-ab0b-1e7b51317c75')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
