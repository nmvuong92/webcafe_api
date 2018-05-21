namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_quan_ban : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quans", "BanArr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quans", "BanArr");
        }
    }
}
