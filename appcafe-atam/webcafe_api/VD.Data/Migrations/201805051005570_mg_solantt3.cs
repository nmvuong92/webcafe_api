namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_solantt3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "GopY", c => c.String());
            AddColumn("dbo.DonHangs", "ThoiGianGopY", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "ThoiGianGopY");
            DropColumn("dbo.DonHangs", "GopY");
        }
    }
}
