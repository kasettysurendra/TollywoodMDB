namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameChangesMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieReviews", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.LoginFiles", "LoginId", c => c.Int(nullable: false));
            AddForeignKey("dbo.UserFollowers", "LoginId", "dbo.Logins");
            AddForeignKey("dbo.UserFollowings", "LoginId", "dbo.Logins");
            AddForeignKey("dbo.LoginFiles", "LoginId", "dbo.Logins");
            AddForeignKey("dbo.ReviewReplys", "MovieId", "dbo.Movies");
            AddForeignKey("dbo.MovieVideos", "MovieId", "dbo.Movies");
            AddForeignKey("dbo.Songs", "MovieId", "dbo.Movies");
            AddForeignKey("dbo.MovieReviews", "MovieId", "dbo.Movies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieReviews", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.MovieReviews", "MovieId");
            DropColumn("dbo.LoginFiles", "LoginId");

        }
    }
}
