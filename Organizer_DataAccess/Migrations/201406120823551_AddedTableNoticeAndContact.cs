namespace Organizer_DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTableNoticeAndContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        Name = c.String(),
                        MiddleName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Apartment = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Body = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NoticeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notices");
            DropTable("dbo.Contacts");
        }
    }
}
