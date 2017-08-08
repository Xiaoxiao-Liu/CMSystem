namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undolast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "AnnouncementId", "dbo.Announcements");
            DropIndex("dbo.Comments", new[] { "AnnouncementId" });
            RenameColumn(table: "dbo.Comments", name: "AnnouncementId", newName: "Announcement_AnnouncementId");
            AddColumn("dbo.Comments", "AId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Announcement_AnnouncementId", c => c.Int());
            CreateIndex("dbo.Comments", "Announcement_AnnouncementId");
            AddForeignKey("dbo.Comments", "Announcement_AnnouncementId", "dbo.Announcements", "AnnouncementId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Announcement_AnnouncementId", "dbo.Announcements");
            DropIndex("dbo.Comments", new[] { "Announcement_AnnouncementId" });
            AlterColumn("dbo.Comments", "Announcement_AnnouncementId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "AId");
            RenameColumn(table: "dbo.Comments", name: "Announcement_AnnouncementId", newName: "AnnouncementId");
            CreateIndex("dbo.Comments", "AnnouncementId");
            AddForeignKey("dbo.Comments", "AnnouncementId", "dbo.Announcements", "AnnouncementId", cascadeDelete: true);
        }
    }
}
