namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorFilesTableMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActorFiles",
                c => new
                {
                        //ActorFileID = c.Int(nullable: false,identity:true),
                        Actor_Id = c.Int(nullable: false),
                        ActorProfilePic = c.Binary(nullable: false),
                    })
                .ForeignKey("Actors",a=>a.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActorFiles");
        }
    }
}
