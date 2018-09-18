namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eight : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Code", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "Code", c => c.String(nullable: false, maxLength: 7));
            AddColumn("dbo.Results", "IsAcTive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Code", c => c.String(nullable: false));
            DropColumn("dbo.Results", "IsAcTive");
        }
    }
}
