namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProjectDeveloperMappingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectDeveloper",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        DeveloperId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.DeveloperId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.DeveloperId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.DeveloperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectDeveloper", "DeveloperId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectDeveloper", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectDeveloper", new[] { "DeveloperId" });
            DropIndex("dbo.ProjectDeveloper", new[] { "ProjectId" });
            DropTable("dbo.ProjectDeveloper");
        }
    }
}
