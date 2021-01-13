namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkCommentsToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "TicketId");
            AddForeignKey("dbo.Comments", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Comments", new[] { "TicketId" });
            DropColumn("dbo.Comments", "TicketId");
        }
    }
}
