namespace ProjectManager.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Priority = c.Int(nullable: false),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Project_Id = c.Int(nullable: false),
                        Parent_Task = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        User = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Manager_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "Project_Id" });
            DropIndex("dbo.Projects", new[] { "Manager_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
