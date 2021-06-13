namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorsTablemig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Actor_Id = c.Int(nullable: false, identity: true),
                        Actor_Name = c.String(),
                        Actor_Age = c.Int(nullable: false),
                        No_Of_Movies = c.Int(nullable: false),
                        Date_Of_Birth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Actors");
        }
    }
}
