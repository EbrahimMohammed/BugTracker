namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDueDateAndMakeIdRequired : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Tickets", "DudeDate", "DueDate");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Tickets", "DueDate", "DudeDate");
        }
    }
}
