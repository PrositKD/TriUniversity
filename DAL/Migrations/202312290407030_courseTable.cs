namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Teachers", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "gender", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "profession", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Teachers", "universityName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Teachers", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "password", c => c.String());
            AlterColumn("dbo.Teachers", "universityName", c => c.String());
            AlterColumn("dbo.Teachers", "profession", c => c.String());
            AlterColumn("dbo.Teachers", "gender", c => c.String());
            AlterColumn("dbo.Teachers", "email", c => c.String());
            AlterColumn("dbo.Teachers", "name", c => c.String());
        }
    }
}
