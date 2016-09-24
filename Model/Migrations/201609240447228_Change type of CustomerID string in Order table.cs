namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetypeofCustomerIDstringinOrdertable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CustomerID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "CustomerID", c => c.Long(nullable: false));
        }
    }
}
