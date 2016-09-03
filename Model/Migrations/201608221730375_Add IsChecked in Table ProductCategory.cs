namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCheckedinTableProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategory", "IsSelected");
        }
    }
}
