namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_fix_donhang0805 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "DiaChiGiaoHang", c => c.String());
            AddColumn("dbo.DonHangs", "SDT", c => c.String());
            AddColumn("dbo.DonHangs", "YeuCauKhac", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "YeuCauKhac");
            DropColumn("dbo.DonHangs", "SDT");
            DropColumn("dbo.DonHangs", "DiaChiGiaoHang");
        }
    }
}
