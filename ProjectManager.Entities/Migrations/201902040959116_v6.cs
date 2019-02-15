namespace ProjectManager.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "Parent_Task", c => c.Int());
            AlterColumn("dbo.Tasks", "Priority", c => c.Int());
            AlterColumn("dbo.Tasks", "Start_Date", c => c.DateTime());
            AlterColumn("dbo.Tasks", "End_Date", c => c.DateTime());
            AlterColumn("dbo.Tasks", "User", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "User", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "End_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "Start_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "Priority", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "Parent_Task", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "Name", c => c.String());
        }
    }
}
