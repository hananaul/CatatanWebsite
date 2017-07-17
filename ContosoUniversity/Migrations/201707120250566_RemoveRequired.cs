namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employee", "Addresss", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Addresss", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Person", "Address", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
