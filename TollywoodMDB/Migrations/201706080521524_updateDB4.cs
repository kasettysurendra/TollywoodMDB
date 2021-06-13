namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MovieImages");
            AddColumn("dbo.MovieImages", "MovieId", c => c.Int(nullable: false));
            AddForeignKey("dbo.MovieImages", "MovieId","dbo.Movies");
            DropColumn("dbo.MovieImages", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieImages", "Movie_Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.MovieImages");
            DropColumn("dbo.MovieImages", "MovieId");
            AddPrimaryKey("dbo.MovieImages", "Movie_Id");
        }
    }
}
