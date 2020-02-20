namespace PassionProject_N01329988.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candyy1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candies",
                c => new
                    {
                        CandyId = c.Int(nullable: false, identity: true),
                        CandyName = c.String(),
                        CandyPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CandyId);
            
            AddColumn("dbo.Orders", "OrderQty", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderPay", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CandyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerID");
            CreateIndex("dbo.Orders", "CandyId");
            AddForeignKey("dbo.Orders", "CandyId", "dbo.Candies", "CandyId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CandyId", "dbo.Candies");
            DropIndex("dbo.Orders", new[] { "CandyId" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropColumn("dbo.Orders", "CandyId");
            DropColumn("dbo.Orders", "CustomerID");
            DropColumn("dbo.Orders", "OrderPay");
            DropColumn("dbo.Orders", "OrderQty");
            DropTable("dbo.Candies");
        }
    }
}
