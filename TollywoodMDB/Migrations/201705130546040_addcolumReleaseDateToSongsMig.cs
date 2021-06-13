namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumReleaseDateToSongsMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "ReleaseDate");
        }
    }
}
