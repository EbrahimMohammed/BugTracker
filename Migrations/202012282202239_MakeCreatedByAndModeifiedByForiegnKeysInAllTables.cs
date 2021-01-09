namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCreatedByAndModeifiedByForiegnKeysInAllTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Priorities", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Priorities", "ModifiedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "ModifiedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "ModifiedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.TicketStatus", "CreatedBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.TicketStatus", "ModifiedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Priorities", "CreatedBy");
            CreateIndex("dbo.Priorities", "ModifiedBy");
            CreateIndex("dbo.Projects", "CreatedBy");
            CreateIndex("dbo.Projects", "ModifiedBy");
            CreateIndex("dbo.Tickets", "CreatedBy");
            CreateIndex("dbo.Tickets", "ModifiedBy");
            CreateIndex("dbo.TicketStatus", "CreatedBy");
            CreateIndex("dbo.TicketStatus", "ModifiedBy");
            AddForeignKey("dbo.Projects", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ModifiedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Priorities", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Priorities", "ModifiedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "ModifiedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TicketStatus", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TicketStatus", "ModifiedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketStatus", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketStatus", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Priorities", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Priorities", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.TicketStatus", new[] { "ModifiedBy" });
            DropIndex("dbo.TicketStatus", new[] { "CreatedBy" });
            DropIndex("dbo.Tickets", new[] { "ModifiedBy" });
            DropIndex("dbo.Tickets", new[] { "CreatedBy" });
            DropIndex("dbo.Projects", new[] { "ModifiedBy" });
            DropIndex("dbo.Projects", new[] { "CreatedBy" });
            DropIndex("dbo.Priorities", new[] { "ModifiedBy" });
            DropIndex("dbo.Priorities", new[] { "CreatedBy" });
            AlterColumn("dbo.TicketStatus", "ModifiedBy", c => c.String());
            AlterColumn("dbo.TicketStatus", "CreatedBy", c => c.String());
            AlterColumn("dbo.Tickets", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Tickets", "CreatedBy", c => c.String());
            AlterColumn("dbo.Projects", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Projects", "CreatedBy", c => c.String());
            AlterColumn("dbo.Priorities", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Priorities", "CreatedBy", c => c.String());
        }
    }
}
