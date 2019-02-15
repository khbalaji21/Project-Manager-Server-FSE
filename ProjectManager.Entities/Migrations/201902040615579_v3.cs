namespace ProjectManager.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Start_Date", c => c.DateTime());
            AlterColumn("dbo.Projects", "End_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "End_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Start_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String());
        }
    }
}
