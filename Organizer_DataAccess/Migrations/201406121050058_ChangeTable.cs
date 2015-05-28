namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notices", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Notices", new[] { "UserId" });
            AddColumn("dbo.Contacts", "UserName", c => c.String());
            AddColumn("dbo.Notices", "UserName", c => c.String());
      
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notices", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Notices", "UserName");
            DropColumn("dbo.Contacts", "UserName");
            CreateIndex("dbo.Notices", "UserId");
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Notices", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
