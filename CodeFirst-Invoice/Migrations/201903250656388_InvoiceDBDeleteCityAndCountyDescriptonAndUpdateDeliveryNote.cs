namespace CodeFirst_Invoice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceDBDeleteCityAndCountyDescriptonAndUpdateDeliveryNote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceHeaders", "DeliveryNote", c => c.Int(nullable: false));
            DropColumn("dbo.Cities", "Description");
            DropColumn("dbo.Counties", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Counties", "Description", c => c.String());
            AddColumn("dbo.Cities", "Description", c => c.String());
            AlterColumn("dbo.InvoiceHeaders", "DeliveryNote", c => c.String());
        }
    }
}
