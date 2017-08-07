namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventControllerCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventDescription = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropTable("dbo.Events");
        }
    }
}
