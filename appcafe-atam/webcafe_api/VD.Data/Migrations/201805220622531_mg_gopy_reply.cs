namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_gopy_reply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GopYReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(),
                        UserReplyId = c.Int(),
                        GopYId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gopies", t => t.GopYId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserReplyId)
                .Index(t => t.UserReplyId)
                .Index(t => t.GopYId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GopYReplies", "UserReplyId", "dbo.Users");
            DropForeignKey("dbo.GopYReplies", "GopYId", "dbo.Gopies");
            DropIndex("dbo.GopYReplies", new[] { "GopYId" });
            DropIndex("dbo.GopYReplies", new[] { "UserReplyId" });
            DropTable("dbo.GopYReplies");
        }
    }
}
