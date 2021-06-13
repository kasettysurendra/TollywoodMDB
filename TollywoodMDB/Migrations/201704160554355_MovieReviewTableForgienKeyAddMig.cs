namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieReviewTableForgienKeyAddMig : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.MovieReviews", "Id", "dbo.Movies");

        }

        public override void Down()
        {
        }
    }
}
