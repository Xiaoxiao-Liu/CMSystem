namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "Role", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Announcements", "Role", c => c.Int(nullable: false));
        }
    }
}
