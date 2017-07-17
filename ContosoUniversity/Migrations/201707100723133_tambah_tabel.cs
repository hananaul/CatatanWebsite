namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambah_tabel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Address", c => c.String());
            AddColumn("dbo.Person", "Phone", c => c.String());
            AddColumn("dbo.Person", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "DateOfBirth");
            DropColumn("dbo.Person", "Phone");
            DropColumn("dbo.Person", "Address");
        }
    }
}
