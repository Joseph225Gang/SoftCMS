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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<MainArticleModel>()
                .HasMany<ReplyModel>(s => s.replyArticles)
                .WithRequired(s => s.mainArticle)
                .HasForeignKey(s => s.ArticleID);
        }
    }
}