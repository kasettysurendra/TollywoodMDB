namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFollowersTablemig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFollowers",
                c => new
                    {
                        LoginId = c.Int(nullable: false),
                        FollowerId = c.Int(nullable: false),
                        RequestStatus = c.String(nullable: false, maxLength: 1),
                        SentDate = c.DateTime(nullable: false,defaultValue:DateTime.Now),
                    })
                .ForeignKey("Logins",t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserFollowers");
        }
    }
}
