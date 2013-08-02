namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRolesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        RoleDescription = c.String(nullable: false),
                        RoleVisualColour = c.String(nullable: false),
                        RoleIdentifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
        }
    }
}
