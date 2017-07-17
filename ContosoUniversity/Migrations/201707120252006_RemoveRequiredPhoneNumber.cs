namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Employee", "PhoneNumber", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "PhoneNumber", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Person", "Phone", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
