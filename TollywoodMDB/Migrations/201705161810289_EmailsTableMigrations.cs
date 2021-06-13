namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailsTableMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailsTables",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity:true),
                        Description = c.String(),
                        EmailContent = c.String(),
                        EntryDate = c.DateTime(nullable: false,defaultValue:DateTime.Now),
                    })
                .PrimaryKey(t => t.EmailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailsTables");
        }
    }
}
