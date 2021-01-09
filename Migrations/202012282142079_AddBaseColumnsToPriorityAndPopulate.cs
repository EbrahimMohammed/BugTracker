namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseColumnsToPriorityAndPopulate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Priorities", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Priorities", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Priorities", "IsEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Priorities", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Priorities", "CreatedBy", c => c.String());
            AddColumn("dbo.Priorities", "ModifiedBy", c => c.String());

            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var adminId = System.Configuration.ConfigurationManager.AppSettings["AdminId"];

            Sql($"INSERT INTO Priorities(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Low', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
            Sql($"INSERT INTO Priorities(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Medium', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
            Sql($"INSERT INTO Priorities(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('High', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
      
        }

        public override void Down()
        {
            DropColumn("dbo.Priorities", "ModifiedBy");
            DropColumn("dbo.Priorities", "CreatedBy");
            DropColumn("dbo.Priorities", "IsDeleted");
            DropColumn("dbo.Priorities", "IsEnabled");
            DropColumn("dbo.Priorities", "ModifiedDate");
            DropColumn("dbo.Priorities", "CreatedDate");
        }
    }
}
