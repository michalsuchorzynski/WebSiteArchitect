namespace WebSiteArchitect.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.Site",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Site");
            DropTable("dbo.Page");
            DropTable("dbo.Menu");
        }
    }
}
