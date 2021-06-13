namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieRatingstableMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieRatings",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        LoginId = c.Int(nullable: false),
                        RatedDate = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                    .ForeignKey("Movies",m=>m.MovieId)
                    .ForeignKey("Logins",l=>l.LoginId)
                    .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieRatings");
        }
    }
}
