namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Six : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocateClassRooms", "AmPmFr", c => c.String(nullable: false));
            AddColumn("dbo.AllocateClassRooms", "AmPmTo", c => c.String());
            DropColumn("dbo.AllocateClassRooms", "TimeFrom");
            DropColumn("dbo.AllocateClassRooms", "TimeTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocateClassRooms", "TimeTo", c => c.String());
            AddColumn("dbo.AllocateClassRooms", "TimeFrom", c => c.String(nullable: false));
            DropColumn("dbo.AllocateClassRooms", "AmPmTo");
            DropColumn("dbo.AllocateClassRooms", "AmPmFr");
        }
    }
}
