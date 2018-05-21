namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_solantt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "LanCuoiGoiTinhTien", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "LanCuoiGoiTinhTien");
        }
    }
}
