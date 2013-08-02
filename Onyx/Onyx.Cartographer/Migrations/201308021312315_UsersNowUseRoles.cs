namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersNowUseRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Role");
        }
    }
}
