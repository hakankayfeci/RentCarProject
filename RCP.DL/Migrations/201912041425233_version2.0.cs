namespace RCP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Phone", c => c.String(nullable: false));
        }
    }
}
