namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTypeinProducttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductType");
        }
    }
}
