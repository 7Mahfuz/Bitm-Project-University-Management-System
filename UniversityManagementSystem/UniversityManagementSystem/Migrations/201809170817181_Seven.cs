namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seven : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AllocateClassRooms", "AmPmFr");
            DropColumn("dbo.AllocateClassRooms", "AmPmTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocateClassRooms", "AmPmTo", c => c.String());
            AddColumn("dbo.AllocateClassRooms", "AmPmFr", c => c.String(nullable: false));
        }
    }
}
