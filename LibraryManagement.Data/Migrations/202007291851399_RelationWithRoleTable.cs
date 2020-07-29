namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationWithRoleTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuRoles", "RoleId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuRoles", "RoleId", c => c.Int(nullable: false));
        }
    }
}
