namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MyProperty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MyProperty");
        }
    }
}
