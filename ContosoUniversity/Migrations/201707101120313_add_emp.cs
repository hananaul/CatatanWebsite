namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_emp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    NameLast = c.String(nullable: false, maxLength: 50),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    DateOfBirthh = c.DateTime(nullable: false),
                    PlaceBirthh = c.String(nullable: false, maxLength: 50),
                    Gender = c.String(nullable: false, maxLength: 50),
                    PhoneNumber = c.String(nullable: false, maxLength: 12),
                    Addresss = c.String(nullable: false, maxLength: 50),
                    PostalCode = c.String(nullable: false, maxLength: 50),
                    MarriedStatus = c.String(nullable: false, maxLength: 50),
                    HireDatee = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

        }
        
        public override void Down()
        {
        }
    }
}
