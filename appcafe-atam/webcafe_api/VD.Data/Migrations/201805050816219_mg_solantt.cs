namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_solantt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "SoLanGoiTinhTien", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "SoLanGoiTinhTien");
        }
    }
}
