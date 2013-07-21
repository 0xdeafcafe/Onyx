namespace Onyx.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sessions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SessionToken = c.String(),
                    })
                .PrimaryKey(t => t.Id)
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
