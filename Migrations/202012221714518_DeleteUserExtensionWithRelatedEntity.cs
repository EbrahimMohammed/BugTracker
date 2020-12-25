namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserExtensionWithRelatedEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserExtensions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserExtensions", new[] { "UserId" });
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String());
            AlterColumn("dbo.Projects", "ModifiedBy", c => c.String());
            DropTable("dbo.UserExtensions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserExtensions",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            AlterColumn("dbo.Projects", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String(nullable: false));
            CreateIndex("dbo.UserExtensions", "UserId");
            AddForeignKey("dbo.UserExtensions", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
