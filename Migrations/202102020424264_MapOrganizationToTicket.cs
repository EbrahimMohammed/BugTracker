namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapOrganizationToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "OrganizationId", c => c.Int());
            CreateIndex("dbo.Tickets", "OrganizationId");
            AddForeignKey("dbo.Tickets", "OrganizationId", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Tickets", new[] { "OrganizationId" });
            DropColumn("dbo.Tickets", "OrganizationId");
        }
    }
}
