namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAccountTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Firstname", c => c.String(maxLength: 25));
            AddColumn("dbo.Accounts", "Lastname", c => c.String(maxLength: 25));
            AddColumn("dbo.Accounts", "Country", c => c.String(maxLength: 20));
            AddColumn("dbo.Accounts", "City", c => c.String(maxLength: 20));
            AddColumn("dbo.Accounts", "PostCode", c => c.String(maxLength: 8));
            DropColumn("dbo.Accounts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Accounts", "PostCode");
            DropColumn("dbo.Accounts", "City");
            DropColumn("dbo.Accounts", "Country");
            DropColumn("dbo.Accounts", "Lastname");
            DropColumn("dbo.Accounts", "Firstname");
        }
    }
}
