namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapTicketToFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Files", "TicketId");
            AddForeignKey("dbo.Files", "TicketId", "dbo.Tickets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Files", new[] { "TicketId" });
            DropColumn("dbo.Files", "TicketId");
        }
    }
}
