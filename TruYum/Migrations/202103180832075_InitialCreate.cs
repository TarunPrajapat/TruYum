namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItem", t => t.MenuItem_Id)
                .Index(t => t.MenuItem_Id);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        FreeDelivery = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateOfLaunch = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "MenuItem_Id", "dbo.MenuItem");
            DropForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "MenuItem_Id" });
            DropTable("dbo.Category");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Cart");
        }
    }
}
