namespace PassionProject_N01329988.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candyy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerContact", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerContact");
        }
    }
}
