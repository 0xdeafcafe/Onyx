namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSessionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sessions", new[] { "UserId" });
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropTable("dbo.Sessions");
        }
    }
}
