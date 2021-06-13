namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewReplyTableandUpdatesmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewReplys",
                c => new
                {
                    ReviewId = c.Int(nullable: false, identity: true),
                    CommentId = c.Int(nullable: false),
                    Reply = c.String(nullable: false),
                    ReplyDate = c.DateTime(nullable: false,defaultValue:DateTime.Now),
                    Id=c.Int(nullable:false)
                })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.MovieReviews", t => t.CommentId)
                .ForeignKey("dbo.Movies",t=>t.Id)
                .Index(t=>t.Id)
                .Index(t => t.CommentId);

        }

        public override void Down()
        {
            DropTable("dbo.ReviewReplys");
        }
    }
}
