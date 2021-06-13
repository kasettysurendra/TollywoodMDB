namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesTableChangesMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieDirector", c => c.String());
            AddColumn("dbo.Movies", "MusicDirector", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MusicDirector");
            DropColumn("dbo.Movies", "MovieDirector");
        }
    }
}
