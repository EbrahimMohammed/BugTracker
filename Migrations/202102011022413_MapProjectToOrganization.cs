namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapProjectToOrganization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "OrganizationId", c => c.Int());
            CreateIndex("dbo.Projects", "OrganizationId");
            AddForeignKey("dbo.Projects", "OrganizationId", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Projects", new[] { "OrganizationId" });
            DropColumn("dbo.Projects", "OrganizationId");
        }
    }
}
