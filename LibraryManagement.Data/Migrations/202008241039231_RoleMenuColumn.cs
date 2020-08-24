namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleMenuColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuRoles", "IsUpdate", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenuRoles", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenuRoles", "IsCreate", c => c.Boolean(nullable: false));
            DropColumn("dbo.RoleOfMenus", "IsUpdate");
            DropColumn("dbo.RoleOfMenus", "IsDelete");
            DropColumn("dbo.RoleOfMenus", "IsCreate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoleOfMenus", "IsCreate", c => c.Boolean(nullable: false));
            AddColumn("dbo.RoleOfMenus", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.RoleOfMenus", "IsUpdate", c => c.Boolean(nullable: false));
            DropColumn("dbo.MenuRoles", "IsCreate");
            DropColumn("dbo.MenuRoles", "IsDelete");
            DropColumn("dbo.MenuRoles", "IsUpdate");
        }
    }
}
