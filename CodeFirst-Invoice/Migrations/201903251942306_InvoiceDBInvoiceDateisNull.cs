namespace CodeFirst_Invoice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceDBInvoiceDateisNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceHeaders", "InvoiceDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceHeaders", "InvoiceDate", c => c.DateTime(nullable: false));
        }
    }
}
