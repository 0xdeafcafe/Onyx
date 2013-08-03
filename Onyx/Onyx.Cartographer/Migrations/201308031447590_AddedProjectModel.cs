namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        SolutionId = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropForeignKey("dbo.Projects", "UserId", "dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
