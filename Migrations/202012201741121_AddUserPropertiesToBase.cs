namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPropertiesToBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreatedBy", c => c.String(nullable: false));
            AddColumn("dbo.Projects", "ModifiedBy", c => c.String(nullable: false));
            AddColumn("dbo.UserExtensions", "CreatedBy", c => c.String(nullable: false));
            AddColumn("dbo.UserExtensions", "ModifiedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserExtensions", "ModifiedBy");
            DropColumn("dbo.UserExtensions", "CreatedBy");
            DropColumn("dbo.Projects", "ModifiedBy");
            DropColumn("dbo.Projects", "CreatedBy");
        }
    }
}
