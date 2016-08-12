namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredPostCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PostCode", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PostCode", c => c.String(nullable: false, maxLength: 8));
        }
    }
}
