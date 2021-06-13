namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdatemig : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFollowings", "FollowId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserFollowings");
            AlterColumn("dbo.UserFollowings", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserFollowings", "FollowId");
        }
    }
}
