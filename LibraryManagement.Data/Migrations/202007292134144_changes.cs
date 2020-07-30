namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MenuRoles", "MenuId");
            AddForeignKey("dbo.MenuRoles", "MenuId", "dbo.Menus", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuRoles", "MenuId", "dbo.Menus");
            DropIndex("dbo.MenuRoles", new[] { "MenuId" });
        }
    }
}
