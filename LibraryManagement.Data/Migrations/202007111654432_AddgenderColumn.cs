namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddgenderColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Gender");
        }
    }
}
