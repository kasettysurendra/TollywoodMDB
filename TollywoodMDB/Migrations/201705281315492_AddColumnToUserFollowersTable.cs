namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToUserFollowersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFollowers", "ReadStatus", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserFollowers", "ReadStatus");
        }
    }
}
