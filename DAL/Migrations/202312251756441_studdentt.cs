namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studdentt : DbMigration
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
                        Gender = c.Int(nullable: false),
                        Active = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentComments", "PostId", "dbo.StudentPosts");
            DropForeignKey("dbo.StudentPosts", "PostedBy", "dbo.Students");
            DropForeignKey("dbo.StudentComments", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentPosts", new[] { "PostedBy" });
            DropIndex("dbo.StudentComments", new[] { "Student_Id" });
            DropIndex("dbo.StudentComments", new[] { "PostId" });
            DropTable("dbo.StudentPosts");
            DropTable("dbo.Students");
            DropTable("dbo.StudentComments");
            DropTable("dbo.Admins");
        }
    }
}
