namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTablem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Phone", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
        }
    }
}
