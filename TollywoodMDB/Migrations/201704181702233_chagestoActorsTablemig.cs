namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chagestoActorsTablemig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Actor_Address", c => c.String());
            AddColumn("dbo.Actors", "Actor_Twitter_Id", c => c.String());
            AddColumn("dbo.Actors", "Actor_Facebook_Id", c => c.String());
            AlterColumn("dbo.Actors", "Actor_Name", c => c.String(nullable: false));
            DropColumn("dbo.Actors", "Actor_Age");
            DropColumn("dbo.Actors", "No_Of_Movies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "No_Of_Movies", c => c.Int(nullable: false));
            AddColumn("dbo.Actors", "Actor_Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Actors", "Actor_Name", c => c.String());
            DropColumn("dbo.Actors", "Actor_Facebook_Id");
            DropColumn("dbo.Actors", "Actor_Twitter_Id");
            DropColumn("dbo.Actors", "Actor_Address");
        }
    }
}
