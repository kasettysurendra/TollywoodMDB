namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongAudiosTableMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongAudios",
                c => new
                {
                    AudioId = c.Int(nullable: false, identity: true),
                    SongId = c.Int(nullable: false),
                    AudioFile = c.Binary(nullable: false),
                })
                .ForeignKey("dbo.Songs", s => s.SongId)
                .PrimaryKey(t => t.AudioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SongAudios");
        }
    }
}
