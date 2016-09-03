namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "SKU", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Product", "ShortDescription", c => c.String(maxLength: 200));
            DropColumn("dbo.Product", "Code");
            DropColumn("dbo.Product", "Quantity");
            DropColumn("dbo.Product", "Detail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Detail", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Code", c => c.String(maxLength: 10, unicode: false));
            DropColumn("dbo.Product", "ShortDescription");
            DropColumn("dbo.Product", "SKU");
        }
    }
}
