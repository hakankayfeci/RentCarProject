namespace RCP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Photo = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            AddColumn("dbo.BlogComment", "UserId", c => c.Int());
            CreateIndex("dbo.Blog", "UserId");
            CreateIndex("dbo.BlogComment", "BlogId");
            CreateIndex("dbo.BlogComment", "UserId");
            AddForeignKey("dbo.Blog", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogComment", "BlogId", "dbo.Blog", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogComment", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPhoto", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.BlogComment", "UserId", "dbo.User");
            DropForeignKey("dbo.BlogComment", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Blog", "UserId", "dbo.User");
            DropIndex("dbo.BlogPhoto", new[] { "BlogId" });
            DropIndex("dbo.BlogComment", new[] { "UserId" });
            DropIndex("dbo.BlogComment", new[] { "BlogId" });
            DropIndex("dbo.Blog", new[] { "UserId" });
            DropColumn("dbo.BlogComment", "UserId");
            DropTable("dbo.BlogPhoto");
        }
    }
}
