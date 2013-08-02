namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedRoleFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Roles", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Roles", "VisualColour", c => c.String(nullable: false));
            AddColumn("dbo.Roles", "Identifier", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "RoleName");
            DropColumn("dbo.Roles", "RoleDescription");
            DropColumn("dbo.Roles", "RoleVisualColour");
            DropColumn("dbo.Roles", "RoleIdentifier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "RoleIdentifier", c => c.Int(nullable: false));
            AddColumn("dbo.Roles", "RoleVisualColour", c => c.String(nullable: false));
            AddColumn("dbo.Roles", "RoleDescription", c => c.String(nullable: false));
            AddColumn("dbo.Roles", "RoleName", c => c.String(nullable: false));
            DropColumn("dbo.Roles", "Identifier");
            DropColumn("dbo.Roles", "VisualColour");
            DropColumn("dbo.Roles", "Description");
            DropColumn("dbo.Roles", "Name");
        }
    }
}
