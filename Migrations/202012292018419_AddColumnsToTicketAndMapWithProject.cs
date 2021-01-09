namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToTicketAndMapWithProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "DudeDate", c => c.DateTime());
            AddColumn("dbo.Tickets", "AssignedDeveloperId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "AssignedDeveloperId");
            CreateIndex("dbo.Tickets", "ProjectId");
            AddForeignKey("dbo.Tickets", "AssignedDeveloperId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tickets", "AssignedDeveloperId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            DropIndex("dbo.Tickets", new[] { "AssignedDeveloperId" });
            DropColumn("dbo.Tickets", "ProjectId");
            DropColumn("dbo.Tickets", "AssignedDeveloperId");
            DropColumn("dbo.Tickets", "DudeDate");
        }
    }
}
