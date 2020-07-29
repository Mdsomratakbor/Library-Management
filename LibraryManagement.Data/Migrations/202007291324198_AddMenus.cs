namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuName = c.String(nullable: false),
                        Controller = c.String(),
                        Action = c.String(),
                        ProjectName = c.String(),
                        ParentId = c.Int(nullable: false),
                        IsParent = c.Boolean(nullable: false),
                        Icon = c.String(nullable: false),
                        EntryDate = c.DateTime(),
                        LUserID = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateLUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
