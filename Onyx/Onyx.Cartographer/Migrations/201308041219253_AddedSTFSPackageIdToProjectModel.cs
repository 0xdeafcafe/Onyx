namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSTFSPackageIdToProjectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "StfsId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "StfsId");
        }
    }
}
