namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserExtensionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserExtensions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserExtensions", new[] { "User_Id" });
            DropTable("dbo.UserExtensions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserExtensions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserExtensions", "User_Id");
            AddForeignKey("dbo.UserExtensions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
