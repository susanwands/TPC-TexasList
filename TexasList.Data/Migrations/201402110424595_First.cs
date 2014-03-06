namespace TexasList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AdBody = c.String(),
                        Amount = c.String(),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.CityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.PostSubcategories",
                c => new
                    {
                        PostSubcategoryId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostSubcategoryId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.SubcategoryId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryId = c.Int(nullable: false, identity: true),
                        SubcategoryName = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubcategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.PostSubcategories", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PostSubcategories", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.PostSubcategories", new[] { "SubcategoryId" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.PostSubcategories", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CityId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Subcategories");
            DropTable("dbo.PostSubcategories");
            DropTable("dbo.Cities");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
