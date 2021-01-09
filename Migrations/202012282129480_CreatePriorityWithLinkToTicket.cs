namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePriorityWithLinkToTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "PriorityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "PriorityId");
            AddForeignKey("dbo.Tickets", "PriorityId", "dbo.Priorities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.Tickets", new[] { "PriorityId" });
            DropColumn("dbo.Tickets", "PriorityId");
            DropTable("dbo.Priorities");
        }
    }
}
