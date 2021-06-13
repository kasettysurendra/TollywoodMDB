namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikesAndDislikesToMoviesMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "DisLikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DisLikes");
            DropColumn("dbo.Movies", "Likes");
        }
    }
}
