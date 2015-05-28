namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskPriorities", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskPriorities", "Name", c => c.String());
        }
    }
}
