namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addladd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentMgs", "DateOfMgs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentMgs", "DateOfMgs", c => c.DateTime());
        }
    }
}
