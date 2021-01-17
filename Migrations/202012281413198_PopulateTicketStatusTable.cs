
namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTicketStatusTable : DbMigration
    {
        public override void Up()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var adminId = System.Configuration.ConfigurationManager.AppSettings["AdminId"];

            Sql($"INSERT INTO TicketStatus(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Pending', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
            Sql($"INSERT INTO TicketStatus(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Assigned', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
            Sql($"INSERT INTO TicketStatus(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Fixed', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
            Sql($"INSERT INTO TicketStatus(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Tested', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
            Sql($"INSERT INTO TicketStatus(Name, CreatedDate, ModifiedDate, IsEnabled, IsDeleted, CreatedBy, ModifiedBy) VALUES('Closed', '{date}', '{date}',1,0,'{adminId}','{adminId}')");
        }
        
        public override void Down()
        {

        }
    }
}
