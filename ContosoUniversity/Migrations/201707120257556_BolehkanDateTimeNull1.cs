namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BolehkanDateTimeNull1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Employee", "PlaceOfBirth", c => c.String(maxLength: 50));
            DropColumn("dbo.Employee", "DateOfBirthh");
            DropColumn("dbo.Employee", "PlaceBirthh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "PlaceBirthh", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employee", "DateOfBirthh", c => c.DateTime(nullable: false));
            DropColumn("dbo.Employee", "PlaceOfBirth");
            DropColumn("dbo.Employee", "DateOfBirth");
        }
    }
}
