namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAdminAndRole : DbMigration
    {
        public override void Up()
        {

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8a71a73a-b056-4407-98f4-4cad0430500a', N'Admin')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3fdb40f1-f117-4233-8440-45a3c454cc24', N'admin@lexa.com', 0, N'AAxMUCYTOZrtqj8fk/l+sFwcUdKZXs9khCKCWdvqgEvr0RUNyj6TPNAlUgCjaxdhjQ==', N'1146778e-5b93-460c-8054-9c4356467c3e', NULL, 0, 0, NULL, 1, 0, N'admin@lexa.com')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3fdb40f1-f117-4233-8440-45a3c454cc24', N'8a71a73a-b056-4407-98f4-4cad0430500a')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
