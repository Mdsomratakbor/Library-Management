namespace LibraryManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookName = c.Int(nullable: false),
                        Isbn = c.Int(nullable: false),
                        AuthorName = c.String(),
                        BookPublish = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookEdition = c.String(),
                        BookQty = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ExpiraryDate = c.DateTime(nullable: false),
                        StudentID = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Semester = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.StudentPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Returns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        StudentID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.StudentID)
                .Index(t => t.StaffID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DesignationID = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        LUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateLUserID = c.Int(nullable: false),
                        Designations_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Designations", t => t.Designations_ID)
                .Index(t => t.Designations_ID);
            
            CreateTable(
                "dbo.StaffPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.StaffID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Returns", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Returns", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.StaffPictures", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.StaffPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Staffs", "Designations_ID", "dbo.Designations");
            DropForeignKey("dbo.Returns", "BookID", "dbo.Books");
            DropForeignKey("dbo.Issues", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentPictures", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Students", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Issues", "BookID", "dbo.Books");
            DropForeignKey("dbo.BookPictures", "BookID", "dbo.Books");
            DropForeignKey("dbo.BookPictures", "PictureID", "dbo.Pictures");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.StaffPictures", new[] { "PictureID" });
            DropIndex("dbo.StaffPictures", new[] { "StaffID" });
            DropIndex("dbo.Staffs", new[] { "Designations_ID" });
            DropIndex("dbo.Returns", new[] { "StaffID" });
            DropIndex("dbo.Returns", new[] { "StudentID" });
            DropIndex("dbo.Returns", new[] { "BookID" });
            DropIndex("dbo.StudentPictures", new[] { "PictureID" });
            DropIndex("dbo.StudentPictures", new[] { "StudentID" });
            DropIndex("dbo.Students", new[] { "DepartmentID" });
            DropIndex("dbo.Issues", new[] { "StudentID" });
            DropIndex("dbo.Issues", new[] { "BookID" });
            DropIndex("dbo.BookPictures", new[] { "PictureID" });
            DropIndex("dbo.BookPictures", new[] { "BookID" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.StaffPictures");
            DropTable("dbo.Staffs");
            DropTable("dbo.Returns");
            DropTable("dbo.StudentPictures");
            DropTable("dbo.Students");
            DropTable("dbo.Issues");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Books");
            DropTable("dbo.Pictures");
            DropTable("dbo.BookPictures");
        }
    }
}
