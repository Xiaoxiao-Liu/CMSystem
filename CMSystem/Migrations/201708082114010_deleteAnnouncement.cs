namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteAnnouncement : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "AId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "AId", c => c.Int(nullable: false));
        }
    }
}
