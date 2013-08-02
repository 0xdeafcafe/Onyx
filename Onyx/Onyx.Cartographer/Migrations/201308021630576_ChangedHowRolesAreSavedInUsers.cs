namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedHowRolesAreSavedInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            CreateIndex("dbo.Users", "RoleId");
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropColumn("dbo.Users", "RoleId");
        }
    }
}
