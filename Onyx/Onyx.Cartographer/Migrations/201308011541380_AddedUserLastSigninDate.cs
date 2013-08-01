namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserLastSigninDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastSigninDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastSigninDate");
        }
    }
}
