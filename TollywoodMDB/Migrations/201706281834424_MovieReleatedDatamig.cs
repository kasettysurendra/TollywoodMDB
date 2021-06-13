namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieReleatedDatamig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieReleatedData",
                c => new
                    {
                        DataId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        DataCategory = c.Int(nullable: false),
                        DataSubCategory = c.String(),
                        Data = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DataId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieReleatedDatas", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieReleatedDatas", new[] { "MovieId" });
            DropTable("dbo.MovieReleatedDatas");
        }
    }
}
