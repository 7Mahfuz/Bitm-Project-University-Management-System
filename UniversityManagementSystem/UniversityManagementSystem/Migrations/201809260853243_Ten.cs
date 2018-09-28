namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ten : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllocateClassRooms", "From", c => c.String(nullable: false));
            AlterColumn("dbo.AllocateClassRooms", "To", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.StudentEnrollInCourses", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentEnrollInCourses", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AllocateClassRooms", "To", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AllocateClassRooms", "From", c => c.DateTime(nullable: false));
        }
    }
}
