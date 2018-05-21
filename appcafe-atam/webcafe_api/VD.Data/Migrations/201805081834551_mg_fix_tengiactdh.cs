namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_fix_tengiactdh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CTDonHangs", "TenGia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CTDonHangs", "TenGia");
        }
    }
}
