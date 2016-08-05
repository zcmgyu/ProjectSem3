namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreateBy", c => c.String(maxLength: 4));
            AddColumn("dbo.AspNetUsers", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "CreateBy");
            DropColumn("dbo.AspNetUsers", "UpdateDate");
            DropColumn("dbo.AspNetUsers", "CreateDate");
        }
    }
}
