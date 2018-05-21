namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixthucdon1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CTDonHangs", "ThucDonId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CTDonHangs", "ThucDonId", c => c.Int());
        }
    }
}
