namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        DateOfBuying = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Orders", "CourseId", "dbo.Courses");
            DropIndex("dbo.Orders", new[] { "CourseId" });
            DropIndex("dbo.Orders", new[] { "StudentId" });
            DropTable("dbo.Orders");
        }
    }
}
