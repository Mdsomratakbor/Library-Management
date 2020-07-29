namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveColumnInMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "IsActinve", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "IsActinve");
        }
    }
}
