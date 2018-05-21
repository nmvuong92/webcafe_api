namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_tienthuatrakhach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "TienKhachDua", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "TienKhachDua");
        }
    }
}
