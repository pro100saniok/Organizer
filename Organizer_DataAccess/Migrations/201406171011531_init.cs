namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagNotices",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Notice_NoticeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Notice_NoticeId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Notices", t => t.Notice_NoticeId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Notice_NoticeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagNotices", "Notice_NoticeId", "dbo.Notices");
            DropForeignKey("dbo.TagNotices", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagNotices", new[] { "Notice_NoticeId" });
            DropIndex("dbo.TagNotices", new[] { "Tag_TagId" });
            DropTable("dbo.TagNotices");
        }
    }
}
