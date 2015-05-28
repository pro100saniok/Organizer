namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdedTaskAndPriority : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskPriorities",
                c => new
                    {
                        TaskPriorityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TaskPriorityId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        TaskPriorityId = c.Int(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.TaskPriorities", t => t.TaskPriorityId)
                .Index(t => t.TaskPriorityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskPriorityId", "dbo.TaskPriorities");
            DropIndex("dbo.Tasks", new[] { "TaskPriorityId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskPriorities");
        }
    }
}
