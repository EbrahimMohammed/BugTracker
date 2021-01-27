namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProjectDevelopersToUsers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectDeveloper", newName: "ProjectUser");
            RenameColumn(table: "dbo.ProjectUser", name: "DeveloperId", newName: "UserId");
            RenameIndex(table: "dbo.ProjectUser", name: "IX_DeveloperId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProjectUser", name: "IX_UserId", newName: "IX_DeveloperId");
            RenameColumn(table: "dbo.ProjectUser", name: "UserId", newName: "DeveloperId");
            RenameTable(name: "dbo.ProjectUser", newName: "ProjectDeveloper");
        }
    }
}
