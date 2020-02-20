namespace PassionProject_N01329988.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Candy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.Int(nullable: false));
        }
    }
}
