namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class announcementId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Announcement_AnnouncementId", "dbo.Announcements");
            DropIndex("dbo.Comments", new[] { "Announcement_AnnouncementId" });
            RenameColumn(table: "dbo.Comments", name: "Announcement_AnnouncementId", newName: "AnnouncementId");
            AlterColumn("dbo.Comments", "AnnouncementId", c => c.Int(nullable: true));
            CreateIndex("dbo.Comments", "AnnouncementId");
            AddForeignKey("dbo.Comments", "AnnouncementId", "dbo.Announcements", "AnnouncementId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "AnnouncementId", "dbo.Announcements");
            DropIndex("dbo.Comments", new[] { "AnnouncementId" });
            AlterColumn("dbo.Comments", "AnnouncementId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "AnnouncementId", newName: "Announcement_AnnouncementId");
            CreateIndex("dbo.Comments", "Announcement_AnnouncementId");
            AddForeignKey("dbo.Comments", "Announcement_AnnouncementId", "dbo.Announcements", "AnnouncementId");
        }
    }
}
