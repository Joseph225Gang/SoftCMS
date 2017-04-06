using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SoftCMS.Models
{
    public class SoftContext : DbContext
    {
        public SoftContext() : base("SoftContext")
        {

        }

        public DbSet<MainArticleModel> MainArticles { get; set; }
        public DbSet<ReplyModel> Replies { get; set; }
        public DbSet<Forum> Categories { get; set; }
        public DbSet<MainThemes> MainThemes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<MainThemes>()
                .HasMany<Forum>(s => s.Topics)
                .WithRequired(s => s.MainThemes)
                .HasForeignKey(s => s.TopicID);
            modelBuilder.Entity<Forum>()
                .HasMany<MainArticleModel>(s => s.MainArticles)
                .WithRequired(s => s.Forum)
                .HasForeignKey(s => s.ForumID);
            modelBuilder.Entity<MainArticleModel>()
                .HasMany<ReplyModel>(s => s.replyArticles)
                .WithRequired(s => s.mainArticle)
                .HasForeignKey(s => s.ArticleID);
        }
    }
}