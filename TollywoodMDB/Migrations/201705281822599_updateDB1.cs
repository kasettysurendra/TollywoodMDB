namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB1 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserFollowers");
            AlterColumn("dbo.UserFollowers", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserFollowers", "id");
        }
    }
}
