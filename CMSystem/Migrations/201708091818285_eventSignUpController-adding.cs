namespace CMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventSignUpControlleradding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventSignUps",
                c => new
                    {
                        EventSignUpId = c.Int(nullable: false, identity: true),
                        SignUpTime = c.DateTime(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EventSignUpId)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Customer_Id)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventSignUps", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.EventSignUps", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EventSignUps", new[] { "Event_EventId" });
            DropIndex("dbo.EventSignUps", new[] { "Customer_Id" });
            DropTable("dbo.EventSignUps");
        }
    }
}
