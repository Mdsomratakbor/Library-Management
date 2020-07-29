namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        IsUpdate = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsCreate = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(),
                        LUserID = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateLUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuRoles", "MenuId", "dbo.Menus");
            DropIndex("dbo.MenuRoles", new[] { "MenuId" });
            DropTable("dbo.MenuRoles");
        }
    }
}
