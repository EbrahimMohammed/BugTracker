namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenTicketAndStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "StatusId");
            AddForeignKey("dbo.Tickets", "StatusId", "dbo.TicketStatus", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.TicketStatus");
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropColumn("dbo.Tickets", "StatusId");
        }
    }
}
