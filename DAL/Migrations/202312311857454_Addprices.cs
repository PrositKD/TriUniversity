namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addprices : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
