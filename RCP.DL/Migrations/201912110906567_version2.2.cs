namespace RCP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version22 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "Email" });
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 450, unicode: false));
            CreateIndex("dbo.User", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Email" });
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            CreateIndex("dbo.User", "Email", unique: true);
        }
    }
}
