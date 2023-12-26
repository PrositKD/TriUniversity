namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newstudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DateOfAccount", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "DateOfAccount");
        }
    }
}
