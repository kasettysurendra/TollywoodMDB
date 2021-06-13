namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasegeneratednullinLoginFilesMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoginFiles", "id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LoginFiles");
            AlterColumn("dbo.LoginFiles", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LoginFiles", "id");
        }
    }
}
