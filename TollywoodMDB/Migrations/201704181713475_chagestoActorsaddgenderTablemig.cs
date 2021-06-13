namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chagestoActorsaddgenderTablemig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Actor_Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "Actor_Gender");
        }
    }
}
