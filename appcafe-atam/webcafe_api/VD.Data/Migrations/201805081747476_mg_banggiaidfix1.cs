namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_banggiaidfix1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CTDonHangs", "GiaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CTDonHangs", "GiaId");
        }
    }
}
