namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_fix_ctdonhang_thucdonid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CTDonHangs", "ThucDonId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CTDonHangs", "ThucDonId");
        }
    }
}
