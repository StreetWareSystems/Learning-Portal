namespace LearningPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 55),
                        Time = c.DateTime(nullable: false),
                        IsActive = c.Boolean(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryName = c.String(nullable: false, maxLength: 75),
                        Time = c.DateTime(nullable: false),
                        IsActive = c.Boolean(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 55),
                        Description = c.String(nullable: false),
                        Levels = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Image = c.String(),
                        SubCategoryId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        IsFeatured = c.Boolean(),
                        UploadedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.CourseLearnings",
                c => new
                    {
                        LearnId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LearnId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        SectionName = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.SectionMedias",
                c => new
                    {
                        SectionMediaId = c.Int(nullable: false, identity: true),
                        VideoTitle = c.String(),
                        Videotype = c.String(),
                        VideoUrl = c.String(),
                        SectionId = c.Int(nullable: false),
                        VideoDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionMediaId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.UserMediaHistories",
                c => new
                    {
                        UserVideoHistoryId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        SectionMediaId = c.Int(nullable: false),
                        WatchedTime = c.Int(nullable: false),
                        UpdatedTime = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserVideoHistoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.SectionMedias", t => t.SectionMediaId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SectionMediaId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        CourseTagId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseTagId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.TagManagers", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TagManagers",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.TagManagers");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.UserMediaHistories", "SectionMediaId", "dbo.SectionMedias");
            DropForeignKey("dbo.UserMediaHistories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SectionMedias", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseLearnings", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserMediaHistories", new[] { "SectionMediaId" });
            DropIndex("dbo.UserMediaHistories", new[] { "UserId" });
            DropIndex("dbo.SectionMedias", new[] { "SectionId" });
            DropIndex("dbo.Sections", new[] { "CourseId" });
            DropIndex("dbo.CourseLearnings", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TagManagers");
            DropTable("dbo.CourseTags");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserMediaHistories");
            DropTable("dbo.SectionMedias");
            DropTable("dbo.Sections");
            DropTable("dbo.CourseLearnings");
            DropTable("dbo.Courses");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
        }
    }
}
