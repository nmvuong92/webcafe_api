namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_fix_danhdaugopy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "DaXemGopY", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonHangs", "ThoiGianXemGopY", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "ThoiGianXemGopY");
            DropColumn("dbo.DonHangs", "DaXemGopY");
        }
    }
}
