namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddatee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentMgs", "DateOfMgsReply", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentMgs", "DateOfMgsReply");
        }
    }
}
