namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_hinhthucmuahang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HinhThucMuaHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DonHangs", "HinhThucMuaHangId", c => c.Int(nullable: false));
            CreateIndex("dbo.DonHangs", "HinhThucMuaHangId");
            AddForeignKey("dbo.DonHangs", "HinhThucMuaHangId", "dbo.HinhThucMuaHangs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "HinhThucMuaHangId", "dbo.HinhThucMuaHangs");
            DropIndex("dbo.DonHangs", new[] { "HinhThucMuaHangId" });
            DropColumn("dbo.DonHangs", "HinhThucMuaHangId");
            DropTable("dbo.HinhThucMuaHangs");
        }
    }
}
