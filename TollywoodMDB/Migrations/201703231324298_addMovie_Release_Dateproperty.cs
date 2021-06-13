namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovie_Release_Dateproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Movie_Release_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Movie_Release_Date");
        }
    }
}
