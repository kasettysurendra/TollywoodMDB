namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieGenrelengthRemovemig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Movie_Genre", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Movie_Genre_Genres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Movie_Genre_Genres", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Movie_Genre");
        }
    }
}
