namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addall : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentMgs", "DateOfMgsReply", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentMgs", "DateOfMgsReply", c => c.DateTime(nullable: false));
        }
    }
}
