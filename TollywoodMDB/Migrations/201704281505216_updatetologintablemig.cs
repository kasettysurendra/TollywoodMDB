namespace TollywoodMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetologintablemig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "NewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "NewsLetter", c => c.String(maxLength: 1));
        }
    }
}
