namespace ProjectManager.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Manager_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "Manager_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Projects", "Manager_Id");
            AddForeignKey("dbo.Projects", "Manager_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
