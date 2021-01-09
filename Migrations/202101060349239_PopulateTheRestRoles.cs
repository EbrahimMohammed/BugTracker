namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTheRestRoles : DbMigration
    {
        public override void Up()
        {

            //Populate users
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e57aa152-850c-4805-b389-252880eb2f5e', N'ProjectManager@lexa.com', 0, N'AO9O9TEGZe/NvtEihjE6vDerl+ebw7sy1dPZIlP+e4vHRY/zAonNSN9J8vqef6Fb5A==', N'e51a42f8-e5c7-4ffe-b8a9-060eded1edab', NULL, 0, 0, NULL, 1, 0, N'ProjectManager@lexa.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'64e31149-2516-440a-b526-83659419f3bb', N'Developer@lexa.com', 0, N'AM0tYlMtJMTQLrakJXPcGZRp9SSc5ji6e5h5xYckQ/DWbPsHSuBGITqycIFd1L5r2A==', N'eeaf0ac9-9049-4d7b-8a6c-7f286198b0a2', NULL, 0, 0, NULL, 1, 0, N'Developer@lexa.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'212d0ffe-18ae-4269-9e2f-13408cc44a9f', N'Tester@lexa.com', 0, N'AIm5vSe4zX19Mjy4f00UYj1/eXlRBBLOLcKt3vyX6xRd0HdPvACEDAvrlOT6OPGByQ==', N'5e7364bf-82c2-4e29-b589-5981aed37b25', NULL, 0, 0, NULL, 1, 0, N'Tester@lexa.com')
               ");

            //Populate Roles
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b009c625-97b5-417d-815f-2cf971b743bf', N'Developer')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'67d50055-0b6f-487e-9d94-5489f4cacb98', N'Project Manager')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7b3a950f-c025-4e85-9582-3db727ceb527', N'Tester')
                ");

            //Populate UserRoles
            Sql(@"
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e57aa152-850c-4805-b389-252880eb2f5e', N'67d50055-0b6f-487e-9d94-5489f4cacb98')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'64e31149-2516-440a-b526-83659419f3bb', N'b009c625-97b5-417d-815f-2cf971b743bf')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'212d0ffe-18ae-4269-9e2f-13408cc44a9f', N'7b3a950f-c025-4e85-9582-3db727ceb527') 
                ");
            
        }
        
        public override void Down()
        {
        }
    }
}
