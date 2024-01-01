namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addladd1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Price", c => c.String(nullable: false));
        }
    }
}
