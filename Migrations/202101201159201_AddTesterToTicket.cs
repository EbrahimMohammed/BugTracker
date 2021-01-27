namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTesterToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "AssignedTesterId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "AssignedTesterId");
            AddForeignKey("dbo.Tickets", "AssignedTesterId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "AssignedTesterId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedTesterId" });
            DropColumn("dbo.Tickets", "AssignedTesterId");
        }
    }
}
