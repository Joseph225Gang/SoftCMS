namespace SoftCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initaladd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainArticleModel",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Subject = c.String(),
                        ReplyCount = c.Int(nullable: false),
                        ContentText = c.String(nullable: false),
                        PublichDate = c.DateTime(nullable: false),
                        CreateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReplyModel",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ArticleID = c.Guid(nullable: false),
                        ArticelMaker = c.String(),
                        ContentText = c.String(nullable: false),
                        PublichDate = c.DateTime(nullable: false),
                        CreateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainArticleModel", t => t.ArticleID, cascadeDelete: true)
                .Index(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReplyModel", "ArticleID", "dbo.MainArticleModel");
            DropIndex("dbo.ReplyModel", new[] { "ArticleID" });
            DropTable("dbo.ReplyModel");
            DropTable("dbo.MainArticleModel");
        }
    }
}
