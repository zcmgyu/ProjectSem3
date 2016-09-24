namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateCountryinOrdertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "ShipCountry", c => c.String(maxLength: 20));
            AddColumn("dbo.Order", "ShipState", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "ShipState");
            DropColumn("dbo.Order", "ShipCountry");
        }
    }
}
