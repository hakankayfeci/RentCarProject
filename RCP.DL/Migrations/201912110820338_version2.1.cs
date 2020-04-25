namespace RCP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertPhoto", "AdvertId", "dbo.Advert");
            DropIndex("dbo.AdvertPhoto", new[] { "AdvertId" });
            CreateTable(
                "dbo.CarPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Photo = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 450, unicode: false));
            CreateIndex("dbo.User", "Username", unique: true);
            CreateIndex("dbo.User", "Email", unique: true);
            DropTable("dbo.AdvertPhoto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdvertPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvertId = c.Int(nullable: false),
                        Photo = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.CarPhoto", "CarId", "dbo.Cars");
            DropIndex("dbo.CarPhoto", new[] { "CarId" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "Username" });
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false));
            DropTable("dbo.CarPhoto");
            CreateIndex("dbo.AdvertPhoto", "AdvertId");
            AddForeignKey("dbo.AdvertPhoto", "AdvertId", "dbo.Advert", "Id", cascadeDelete: true);
        }
    }
}
