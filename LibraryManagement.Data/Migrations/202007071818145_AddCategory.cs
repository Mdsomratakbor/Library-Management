namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: true),
                        LUserID = c.Int(nullable: true),
                        UpdateDate = c.DateTime(nullable: true),
                        UpdateLUserID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Books", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryID");
            AddForeignKey("dbo.Books", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropColumn("dbo.Books", "CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
