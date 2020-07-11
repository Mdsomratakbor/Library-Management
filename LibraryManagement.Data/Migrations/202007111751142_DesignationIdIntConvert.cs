namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesignationIdIntConvert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "Designations_ID", "dbo.Designations");
            DropIndex("dbo.Staffs", new[] { "Designations_ID" });
            DropColumn("dbo.Staffs", "DesignationID");
            RenameColumn(table: "dbo.Staffs", name: "Designations_ID", newName: "DesignationID");
            AlterColumn("dbo.Staffs", "DesignationID", c => c.Int(nullable: false));
            AlterColumn("dbo.Staffs", "DesignationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "DesignationID");
            AddForeignKey("dbo.Staffs", "DesignationID", "dbo.Designations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "DesignationID", "dbo.Designations");
            DropIndex("dbo.Staffs", new[] { "DesignationID" });
            AlterColumn("dbo.Staffs", "DesignationID", c => c.Int());
            AlterColumn("dbo.Staffs", "DesignationID", c => c.String());
            RenameColumn(table: "dbo.Staffs", name: "DesignationID", newName: "Designations_ID");
            AddColumn("dbo.Staffs", "DesignationID", c => c.String());
            CreateIndex("dbo.Staffs", "Designations_ID");
            AddForeignKey("dbo.Staffs", "Designations_ID", "dbo.Designations", "ID");
        }
    }
}
