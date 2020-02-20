namespace PassionProject_N01329988.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandyStore1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerName");
        }
    }
}
