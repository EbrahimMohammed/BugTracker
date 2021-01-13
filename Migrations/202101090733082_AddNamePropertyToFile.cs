namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropertyToFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Name");
        }
    }
}
