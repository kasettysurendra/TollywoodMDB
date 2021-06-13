namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviegenremig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Movie_Genre", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Movie_Genre");
        }
    }
}
