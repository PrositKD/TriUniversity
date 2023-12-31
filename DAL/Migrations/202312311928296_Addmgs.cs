namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmgs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentMgs",
                c => new
                    {
                        MgsId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        DateOfMgs = c.DateTime(nullable: false),
                        Message = c.String(nullable: false),
                        Reply = c.String(),
                    })
                .PrimaryKey(t => t.MgsId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentMgs", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.StudentMgs", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentMgs", new[] { "TeacherId" });
            DropIndex("dbo.StudentMgs", new[] { "StudentId" });
            DropTable("dbo.StudentMgs");
        }
    }
}
