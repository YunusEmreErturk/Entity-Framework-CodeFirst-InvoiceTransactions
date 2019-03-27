namespace CodeFirst_Invoice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceDBAddCityIDForCounty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Counties", "city_CityID", "dbo.Cities");
            DropIndex("dbo.Counties", new[] { "city_CityID" });
            RenameColumn(table: "dbo.Counties", name: "city_CityID", newName: "CityID");
            AlterColumn("dbo.Counties", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Counties", "CityID");
            AddForeignKey("dbo.Counties", "CityID", "dbo.Cities", "CityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Counties", "CityID", "dbo.Cities");
            DropIndex("dbo.Counties", new[] { "CityID" });
            AlterColumn("dbo.Counties", "CityID", c => c.Int());
            RenameColumn(table: "dbo.Counties", name: "CityID", newName: "city_CityID");
            CreateIndex("dbo.Counties", "city_CityID");
            AddForeignKey("dbo.Counties", "city_CityID", "dbo.Cities", "CityID");
        }
    }
}
