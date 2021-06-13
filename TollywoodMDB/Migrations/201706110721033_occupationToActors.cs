namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class occupationToActors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Actor_Occupation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "Actor_Occupation");
        }
    }
}
