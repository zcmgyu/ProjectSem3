namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovequestionmarkfromCustomerIDinOrdertable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CustomerID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "CustomerID", c => c.Long());
        }
    }
}
