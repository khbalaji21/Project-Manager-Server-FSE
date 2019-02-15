namespace ProjectManager.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Manager_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "Manager_Id" });
            AlterColumn("dbo.Projects", "Manager_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "Manager_Id");
            AddForeignKey("dbo.Projects", "Manager_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Manager_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "Manager_Id" });
            AlterColumn("dbo.Projects", "Manager_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Manager_Id");
            AddForeignKey("dbo.Projects", "Manager_Id", "dbo.Users", "Id");
        }
    }
}
