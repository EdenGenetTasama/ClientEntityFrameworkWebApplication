namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyClasses", "Name", c => c.String());
            AddColumn("dbo.MyClasses", "CarNumber", c => c.Int(nullable: false));
            AddColumn("dbo.MyClasses", "Status", c => c.String());
            DropColumn("dbo.MyClasses", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyClasses", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.MyClasses", "Status");
            DropColumn("dbo.MyClasses", "CarNumber");
            DropColumn("dbo.MyClasses", "Name");
        }
    }
}
