namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Year");
        }
    }
}
