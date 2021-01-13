namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(maxLength: 1000),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        ModifiedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ModifiedBy" });
            DropIndex("dbo.Comments", new[] { "CreatedBy" });
            DropTable("dbo.Comments");
        }
    }
}
