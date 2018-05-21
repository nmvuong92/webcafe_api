namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_add_banggiact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangGiaCTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Ten = c.String(),
                        Price = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BangGiaCTs", "ProductId", "dbo.Products");
            DropIndex("dbo.BangGiaCTs", new[] { "ProductId" });
            DropTable("dbo.BangGiaCTs");
        }
    }
}
