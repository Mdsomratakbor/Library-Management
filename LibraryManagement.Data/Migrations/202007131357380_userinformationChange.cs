namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userinformationChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Country");
            DropColumn("dbo.User", "City");
            DropColumn("dbo.User", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Address", c => c.String());
            AddColumn("dbo.User", "City", c => c.String());
            AddColumn("dbo.User", "Country", c => c.String());
        }
    }
}
