namespace RCP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Advert",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        AdvertNo = c.Int(nullable: false),
                        Explanation = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        StartPrie = c.Int(nullable: false),
                        AdvertStatus = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 25),
                        Brand = c.String(nullable: false, maxLength: 25),
                        Year = c.DateTime(nullable: false),
                        Engine = c.String(nullable: false),
                        Sherry = c.String(nullable: false),
                        Fuel = c.String(nullable: false),
                        Gear = c.String(nullable: false),
                        Km = c.Double(nullable: false),
                        CaseType = c.String(nullable: false, maxLength: 25),
                        EnginePower = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Traction = c.String(nullable: false, maxLength: 25),
                        Waranty = c.Boolean(nullable: false),
                        CarPlate = c.String(),
                        Price = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 25),
                    Surname = c.String(nullable: false, maxLength: 25),
                    Username = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Phone = c.String(nullable: false),
                    RegisterDate = c.DateTime(nullable: false),
                    IsDelete = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advert", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Star = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.AdvertPhoto", "AdvertId", "dbo.Advert");
            DropForeignKey("dbo.Advert", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "AddressId", "dbo.Address");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.AdvertPhoto", new[] { "AdvertId" });
            DropIndex("dbo.User", new[] { "AddressId" });
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropIndex("dbo.Advert", new[] { "CarId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.BlogComment");
            DropTable("dbo.Blog");
            DropTable("dbo.AdvertPhoto");
            DropTable("dbo.User");
            DropTable("dbo.Cars");
            DropTable("dbo.Advert");
            DropTable("dbo.Address");
        }
    }
}
