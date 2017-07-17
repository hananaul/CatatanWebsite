namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_skill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSkill",
                c => new
                    {
                        IDSkill = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        Skill = c.String(nullable: false, maxLength: 50),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDSkill)
                .ForeignKey("dbo.Employee", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSkill", "ID", "dbo.Employee");
            DropIndex("dbo.EmployeeSkill", new[] { "ID" });
            DropTable("dbo.EmployeeSkill");
        }
    }
}
