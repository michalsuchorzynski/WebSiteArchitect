namespace WebSiteArchitect.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Site_SiteId", c => c.Int());
            AddColumn("dbo.Page", "Site_SiteId", c => c.Int());
            CreateIndex("dbo.Menu", "Site_SiteId");
            CreateIndex("dbo.Page", "Site_SiteId");
            AddForeignKey("dbo.Menu", "Site_SiteId", "dbo.Site", "SiteId");
            AddForeignKey("dbo.Page", "Site_SiteId", "dbo.Site", "SiteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Page", "Site_SiteId", "dbo.Site");
            DropForeignKey("dbo.Menu", "Site_SiteId", "dbo.Site");
            DropIndex("dbo.Page", new[] { "Site_SiteId" });
            DropIndex("dbo.Menu", new[] { "Site_SiteId" });
            DropColumn("dbo.Page", "Site_SiteId");
            DropColumn("dbo.Menu", "Site_SiteId");
        }
    }
}
