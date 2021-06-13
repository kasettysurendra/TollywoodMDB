namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovie_Idpropertychangedmig : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MovieImages");
            AlterColumn("dbo.MovieImages", "Movie_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MovieImages", "Movie_Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MovieImages");
            AlterColumn("dbo.MovieImages", "Movie_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MovieImages", "Movie_Id");
        }
    }
}
