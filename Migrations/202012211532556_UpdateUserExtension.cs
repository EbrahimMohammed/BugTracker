namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserExtension : DbMigration
    {
        public override void Up()
        {

            Sql("ALTER TABLE dbo.UserExtensions ADD Id int");

            DropPrimaryKey("dbo.UserExtensions");
            AlterColumn("dbo.UserExtensions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserExtensions", "Id");
        }
        
        public override void Down()
        {
            //DropPrimaryKey("dbo.UserExtensions");
            //AlterColumn("dbo.UserExtensions", "Id", c => c.Int(nullable: false));
            //AlterColumn("dbo.UserExtensions", "User_Id", c => c.String(nullable: false, maxLength: 128));
            //AddPrimaryKey("dbo.UserExtensions", "UserId");
            //RenameColumn(table: "dbo.UserExtensions", name: "User_Id", newName: "UserId");
            //CreateIndex("dbo.UserExtensions", "UserId");
        }
    }
}
