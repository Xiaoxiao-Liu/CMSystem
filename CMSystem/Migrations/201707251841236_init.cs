namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        AnnouncementId = c.Int(nullable: false, identity: true),
                        AnnouncementTitle = c.String(),
                        AnnouncementContent = c.String(),
                        AnnoucingTime = c.DateTime(nullable: false),
                        ExpiryTime = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AnnouncementId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Announcements", new[] { "User_Id" });
            DropTable("dbo.Announcements");
        }
    }
}
