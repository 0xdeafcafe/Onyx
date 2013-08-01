namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserRegistrationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegisterDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RegisterDate");
        }
    }
}
