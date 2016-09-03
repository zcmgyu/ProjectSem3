namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCheckednullableinTableProductCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategory", "IsSelected", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategory", "IsSelected", c => c.Boolean(nullable: false));
        }
    }
}
