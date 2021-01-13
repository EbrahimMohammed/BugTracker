namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(maxLength: 500),
                        Description = c.String(maxLength: 1000),
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
            DropForeignKey("dbo.Files", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Files", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Files", new[] { "ModifiedBy" });
            DropIndex("dbo.Files", new[] { "CreatedBy" });
            DropTable("dbo.Files");
        }
    }
}
