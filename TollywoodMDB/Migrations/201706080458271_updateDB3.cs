namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB3 : DbMigration
    {
        public override void Up()
        {
        
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoginFiles", "id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.LoginFiles");
            DropColumn("dbo.LoginFiles", "LoginId");
            AddPrimaryKey("dbo.LoginFiles", "id");
        }
    }
}
