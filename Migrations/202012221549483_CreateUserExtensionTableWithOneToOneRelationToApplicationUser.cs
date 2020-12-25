namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserExtensionTableWithOneToOneRelationToApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserExtensions",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExtensions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserExtensions", new[] { "UserId" });
            DropTable("dbo.UserExtensions");
        }
    }
}
