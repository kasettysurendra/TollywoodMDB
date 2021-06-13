namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFollowingsTablesMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFollowings",
                c => new
                {
                    //FollowId = c.Int(nullable: false, identity: true),
                    LoginId = c.Int(nullable: false),
                    Actor_Id = c.Int(nullable: false),
                    FollowStartDate = c.DateTime(nullable: false),
                })

                .ForeignKey("Logins", l => l.LoginId)
            .ForeignKey("Actors", a => a.Actor_Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.UserFollowings");
        }
    }
}
