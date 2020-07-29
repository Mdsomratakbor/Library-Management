namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveColumnInMenu1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Menus", "IsActinve");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "IsActinve", c => c.Boolean(nullable: false));
            DropColumn("dbo.Menus", "IsActive");
        }
    }
}
