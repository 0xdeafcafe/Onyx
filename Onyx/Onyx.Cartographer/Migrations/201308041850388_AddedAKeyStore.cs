namespace Onyx.Cartographer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAKeyStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Data = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Keys");
        }
    }
}
