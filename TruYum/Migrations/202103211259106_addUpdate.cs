namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "MenuItem_Id", "dbo.MenuItem");
            DropIndex("dbo.Cart", new[] { "MenuItem_Id" });
            RenameColumn(table: "dbo.Cart", name: "MenuItem_Id", newName: "MenuItemId");
            AlterColumn("dbo.Cart", "MenuItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cart", "MenuItemId");
            AddForeignKey("dbo.Cart", "MenuItemId", "dbo.MenuItem", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "MenuItemId", "dbo.MenuItem");
            DropIndex("dbo.Cart", new[] { "MenuItemId" });
            AlterColumn("dbo.Cart", "MenuItemId", c => c.Int());
            RenameColumn(table: "dbo.Cart", name: "MenuItemId", newName: "MenuItem_Id");
            CreateIndex("dbo.Cart", "MenuItem_Id");
            AddForeignKey("dbo.Cart", "MenuItem_Id", "dbo.MenuItem", "Id");
        }
    }
}
