namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BolehkanDateTimeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Department", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
