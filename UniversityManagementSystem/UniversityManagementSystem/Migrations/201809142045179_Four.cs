namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Credit", c => c.Double(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Credit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
