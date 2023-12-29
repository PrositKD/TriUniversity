namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allahrohomotkoro : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instructors", newName: "Teachers");
            AddColumn("dbo.Students", "DateOfAccount", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Teachers", "confirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "confirmPassword", c => c.String());
            AlterColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "DateOfAccount");
            RenameTable(name: "dbo.Teachers", newName: "Instructors");
        }
    }
}
