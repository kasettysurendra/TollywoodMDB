namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSongsTableMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                {
                    SongId = c.Int(nullable: false, identity: true),
                    MovieId = c.Int(nullable: false),
                    SongName = c.String(nullable: false),
                    SongSingers = c.String(nullable: false),
                })
                .ForeignKey("dbo.Movies",m=>m.MovieId)
                .PrimaryKey(t => t.SongId);

            
        }
        
        public override void Down()
        {
            DropTable("dbo.Songs");
        }
    }
}
