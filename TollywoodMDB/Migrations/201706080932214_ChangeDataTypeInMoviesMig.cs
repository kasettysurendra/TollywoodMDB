namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeInMoviesMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Movie_ratings", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Movie_ratings", c => c.Byte(nullable: false));
        }
    }
}
