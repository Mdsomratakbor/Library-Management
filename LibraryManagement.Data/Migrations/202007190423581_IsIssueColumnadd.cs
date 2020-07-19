namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsIssueColumnadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "IsIssue", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "IsIssue");
        }
    }
}
