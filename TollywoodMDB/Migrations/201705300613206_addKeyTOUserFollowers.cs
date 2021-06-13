namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKeyTOUserFollowers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFollowers", "FollowId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserFollowers", "FollowId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserFollowers");
            DropColumn("dbo.UserFollowers", "FollowId");
        }
    }
}
