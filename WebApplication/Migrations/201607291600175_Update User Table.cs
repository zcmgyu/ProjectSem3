namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AspNetUsers", "District", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AspNetUsers", "PostCode", c => c.String(nullable: false, maxLength: 8));
            DropColumn("dbo.AspNetUsers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MyProperty", c => c.String());
            DropColumn("dbo.AspNetUsers", "PostCode");
            DropColumn("dbo.AspNetUsers", "District");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "DOB");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "Firstname");
        }
    }
}
