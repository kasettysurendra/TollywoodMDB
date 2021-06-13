namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridinReviewReplyMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewReplys", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewReplys", "UserId");
        }
    }
}
