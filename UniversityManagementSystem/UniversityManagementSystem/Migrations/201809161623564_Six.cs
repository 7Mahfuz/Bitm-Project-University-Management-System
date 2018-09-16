namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Six : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocateClassRooms", "TimeFrom", c => c.String(nullable: false));
            AddColumn("dbo.AllocateClassRooms", "TimeTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AllocateClassRooms", "TimeTo");
            DropColumn("dbo.AllocateClassRooms", "TimeFrom");
        }
    }
}
