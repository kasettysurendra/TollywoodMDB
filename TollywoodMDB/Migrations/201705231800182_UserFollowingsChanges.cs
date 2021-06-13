namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFollowingsChanges : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("dbo.UserFollowings", "id", c => c.Int(nullable: false));
        
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserFollowings", "id", c => c.Int(nullable: false, identity: true));
           
        }
    }
}
