namespace CodeFirst_Invoice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceDBAddCountyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Counties", "CountyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Counties", "CountyName");
        }
    }
}
