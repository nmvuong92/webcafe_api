namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_hi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.vd_Job", "IsTop", c => c.Boolean(nullable: false));
            AddColumn("dbo.vd_Job", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.vd_Job", "IsUrgent", c => c.Boolean(nullable: false));
            AddColumn("dbo.vd_Job", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.vd_Job", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.vd_Job", "IsHotJob");
            DropColumn("dbo.vd_Job", "IsNewJob");
        }
        
        public override void Down()
        {
            AddColumn("dbo.vd_Job", "IsNewJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.vd_Job", "IsHotJob", c => c.Boolean(nullable: false));
            DropColumn("dbo.vd_Job", "EndDate");
            DropColumn("dbo.vd_Job", "IsActive");
            DropColumn("dbo.vd_Job", "IsUrgent");
            DropColumn("dbo.vd_Job", "IsHot");
            DropColumn("dbo.vd_Job", "IsTop");
        }
    }
}
