namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAndPopulateTicketTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            

            Sql("INSERT INTO TicketTypes (Type) VALUES ('Bug/Error')");
            Sql("INSERT INTO TicketTypes (Type) VALUES ('Change Request')");
            Sql("INSERT INTO TicketTypes (Type) VALUES ('New functionality')");

        }
        
        public override void Down()
        {
            DropTable("dbo.TicketTypes");
        }
    }
}
