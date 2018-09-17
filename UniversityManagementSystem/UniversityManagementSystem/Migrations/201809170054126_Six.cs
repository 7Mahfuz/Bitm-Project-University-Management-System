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
            AddColumn("dbo.Results", "IsAcTive", c => c.Boolean(nullable: false));
            
        }
        
        public override void Down()
        {
           
            DropColumn("dbo.AllocateClassRooms", "AmPmTo");
            DropColumn("dbo.AllocateClassRooms", "AmPmFr");
            DropColumn("dbo.Results", "IsAcTive");
        }
    }
}
