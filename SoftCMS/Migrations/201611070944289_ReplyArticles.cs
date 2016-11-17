namespace SoftCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplyArticles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainArticleModel", "ReplyCount", c => c.Int(nullable: false));
            DropColumn("dbo.MainArticleModel", "ViewCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainArticleModel", "ViewCount", c => c.Int(nullable: false));
            DropColumn("dbo.MainArticleModel", "ReplyCount");
        }
    }
}
