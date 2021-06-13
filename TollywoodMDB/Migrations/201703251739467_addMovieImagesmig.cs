namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieImagesmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieImages",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false, identity: false),
                        Movie_Icon = c.Binary(),
                        Movie_Background = c.Binary(),
                    })
                .PrimaryKey(t => t.Movie_Id);
            AddForeignKey("dbo.MovieImages", "Movie_Id", "dbo.Movies");
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieImages");
        }
    }
}
