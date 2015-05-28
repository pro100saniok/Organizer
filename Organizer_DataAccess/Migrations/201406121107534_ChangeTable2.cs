namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notices", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Notices", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notices", "Body", c => c.String());
            AlterColumn("dbo.Notices", "Name", c => c.String());
        }
    }
}
