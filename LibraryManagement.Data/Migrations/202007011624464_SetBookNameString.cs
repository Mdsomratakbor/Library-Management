namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBookNameString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String());
            AlterColumn("dbo.Books", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Books", "LUserID", c => c.Int());
            AlterColumn("dbo.Books", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Books", "UpdateLUserID", c => c.Int());
            AlterColumn("dbo.Departments", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "LUserID", c => c.Int());
            AlterColumn("dbo.Departments", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "UpdateLUserID", c => c.Int());
            AlterColumn("dbo.Designations", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Designations", "LUserID", c => c.Int());
            AlterColumn("dbo.Designations", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Designations", "UpdateLUserID", c => c.Int());
            AlterColumn("dbo.Issues", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Issues", "LUserID", c => c.Int());
            AlterColumn("dbo.Issues", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Issues", "UpdateLUserID", c => c.Int());
            AlterColumn("dbo.Students", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Students", "LUserID", c => c.Int());
            AlterColumn("dbo.Students", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Students", "UpdateLUserID", c => c.Int());
            AlterColumn("dbo.Returns", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Returns", "LUserID", c => c.Int());
            AlterColumn("dbo.Returns", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Returns", "UpdateLUserID", c => c.Int());
            AlterColumn("dbo.Staffs", "EntryDate", c => c.DateTime());
            AlterColumn("dbo.Staffs", "LUserID", c => c.Int());
            AlterColumn("dbo.Staffs", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Staffs", "UpdateLUserID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Staffs", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Staffs", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Staffs", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Returns", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Returns", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Returns", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Returns", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Issues", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Issues", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Designations", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Designations", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Designations", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Designations", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "UpdateLUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "LUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "BookName", c => c.Int(nullable: false));
        }
    }
}
