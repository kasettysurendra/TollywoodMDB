namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addviewstoMoviesTablemig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Views");
        }
    }
}
