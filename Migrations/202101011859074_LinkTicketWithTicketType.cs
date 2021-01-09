namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkTicketWithTicketType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketTypeId", c => c.Int(nullable: false, defaultValue:1));
            CreateIndex("dbo.Tickets", "TicketTypeId");
            AddForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes");
            DropIndex("dbo.Tickets", new[] { "TicketTypeId" });
            DropColumn("dbo.Tickets", "TicketTypeId");
        }
    }
}
