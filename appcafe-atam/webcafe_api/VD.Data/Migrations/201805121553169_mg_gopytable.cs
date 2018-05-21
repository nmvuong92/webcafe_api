namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_gopytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gopies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonHangId = c.Int(nullable: false),
                        NoiDungGopY = c.String(),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonHangs", t => t.DonHangId, cascadeDelete: true)
                .Index(t => t.DonHangId);
            
            DropColumn("dbo.DonHangs", "GopY");
            DropColumn("dbo.DonHangs", "DaXemGopY");
            DropColumn("dbo.DonHangs", "ThoiGianXemGopY");
            DropColumn("dbo.DonHangs", "ThoiGianGopY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonHangs", "ThoiGianGopY", c => c.DateTime());
            AddColumn("dbo.DonHangs", "ThoiGianXemGopY", c => c.DateTime());
            AddColumn("dbo.DonHangs", "DaXemGopY", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonHangs", "GopY", c => c.String());
            DropForeignKey("dbo.Gopies", "DonHangId", "dbo.DonHangs");
            DropIndex("dbo.Gopies", new[] { "DonHangId" });
            DropTable("dbo.Gopies");
        }
    }
}
