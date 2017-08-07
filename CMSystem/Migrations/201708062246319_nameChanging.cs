namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameChanging : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "AnnouncementId_AnnouncementId", newName: "Announcement_AnnouncementId");
            RenameColumn(table: "dbo.Comments", name: "UserId_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_AnnouncementId_AnnouncementId", newName: "IX_Announcement_AnnouncementId");
            RenameIndex(table: "dbo.Comments", name: "IX_UserId_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_UserId_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_Announcement_AnnouncementId", newName: "IX_AnnouncementId_AnnouncementId");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserId_Id");
            RenameColumn(table: "dbo.Comments", name: "Announcement_AnnouncementId", newName: "AnnouncementId_AnnouncementId");
        }
    }
}
