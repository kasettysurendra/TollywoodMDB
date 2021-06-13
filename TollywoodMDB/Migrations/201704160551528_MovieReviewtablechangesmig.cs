namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieReviewtablechangesmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieReviews", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.MovieReviews", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieReviews", "Movie_Id", c => c.Int(nullable: false));
            DropColumn("dbo.MovieReviews", "Id");
        }
    }
}
