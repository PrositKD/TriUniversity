namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentMgs", "DateOfMgs", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentMgs", "DateOfMgs", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
