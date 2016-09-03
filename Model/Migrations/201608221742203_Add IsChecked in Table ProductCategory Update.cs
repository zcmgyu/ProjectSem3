namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCheckedinTableProductCategoryUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategory", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategory", "IsSelected", c => c.Boolean());
        }
    }
}
