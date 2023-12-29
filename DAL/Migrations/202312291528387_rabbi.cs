namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rabbi : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Tokens");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
        }
    }
}
