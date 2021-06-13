namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenresmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Movie_Genre_Genres", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Movie_Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Movie_Genre", c => c.String(maxLength: 100));
            DropColumn("dbo.Movies", "Movie_Genre_Genres");
        }
    }
}
