namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserfilesTableMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginFiles",
                c => new
                {
                    //FileId = c.Int(nullable: false, identity: true),
                    id = c.Int(nullable: false),
                    ProfilePicture = c.Binary(nullable: false),
                    UploadedDate = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                })
                .ForeignKey("dbo.Logins", t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginFiles");
        }
    }
}
