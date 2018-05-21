namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_add_product_soluongia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SoLuongGia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SoLuongGia");
        }
    }
}
