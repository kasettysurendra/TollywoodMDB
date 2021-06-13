namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviereviewsTablemig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Comment = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Movies", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieReviews", "Movies_Id", "dbo.Movies");
            DropIndex("dbo.MovieReviews", new[] { "Movies_Id" });
            DropTable("dbo.MovieReviews");
        }
    }
}
