namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "IsEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IsDeleted");
            DropColumn("dbo.Projects", "IsEnabled");
            DropColumn("dbo.Projects", "ModifiedDate");
            DropColumn("dbo.Projects", "CreatedDate");
        }
    }
}
