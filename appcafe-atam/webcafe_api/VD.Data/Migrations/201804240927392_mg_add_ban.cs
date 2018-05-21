namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_add_ban : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "Ban", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "Ban");
        }
    }
}
