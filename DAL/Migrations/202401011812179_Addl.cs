namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentMgs", "DateOfMgs", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentMgs", "DateOfMgs", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
