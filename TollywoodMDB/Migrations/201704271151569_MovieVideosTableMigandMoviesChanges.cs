namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieVideosTableMigandMoviesChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieVideos",
                c => new
                    {
                        MovieVideoId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        VideoTitle = c.String(nullable: false, maxLength: 100),
                        VideoEmbedURl = c.String(nullable: false),
                    })
                    .ForeignKey("dbo.Movies",t=>t.Id)
                .PrimaryKey(t => t.MovieVideoId);
            
            AddColumn("dbo.Movies", "Rating", c => c.Single(nullable: false));
            AddColumn("dbo.Movies", "Votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Votes");
            DropColumn("dbo.Movies", "Rating");
            DropTable("dbo.MovieVideos");
        }
    }
}
