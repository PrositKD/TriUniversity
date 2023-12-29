namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sagorsWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ShortDescription = c.String(maxLength: 500),
                        InstructorName = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                        VideoPath = c.String(nullable: false, maxLength: 200),
                        UploadTime = c.DateTime(nullable: false),
                        ApproveOrNot = c.Boolean(nullable: false),
                        SellCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CommentedBy = c.String(nullable: false),
                        PostId = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.StudentPosts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 15),
                        InstitutionName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        Active = c.Int(nullable: false),
                        DateOfAccount = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Approve = c.Int(nullable: false),
                        PostedBy = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.PostedBy, cascadeDelete: true)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        profession = c.String(nullable: false, maxLength: 100),
                        universityName = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentComments", "PostId", "dbo.StudentPosts");
            DropForeignKey("dbo.StudentPosts", "PostedBy", "dbo.Students");
            DropForeignKey("dbo.StudentComments", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentPosts", new[] { "PostedBy" });
            DropIndex("dbo.StudentComments", new[] { "Student_Id" });
            DropIndex("dbo.StudentComments", new[] { "PostId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Teachers");
            DropTable("dbo.StudentPosts");
            DropTable("dbo.Students");
            DropTable("dbo.StudentComments");
            DropTable("dbo.Courses");
            DropTable("dbo.Admins");
        }
    }
}
