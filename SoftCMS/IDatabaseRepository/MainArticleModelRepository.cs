using SoftCMS.Models;
using SoftCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS.IDatabaseRepository
{
    public class MainArticleModelRepository : IDatabaseRepository
    {
        private DataBaseInitialize dataSave = new SoftContextInitialize();
        private SoftContext db = null;

        public MainArticleModelRepository()
        {
            db = new SoftContext();
        }

        public MainArticleModelRepository(SoftContext db)
        {
            this.db = db;
        }

        async public Task Delete(Guid id)
        {
            MainArticleModel mainArticleModel = db.MainArticles.Find(id);
            db.MainArticles.Remove(mainArticleModel);
            await dataSave.Save(db);
        }

        async public Task Insert(object obj)
        {
            MainArticleModel mainArticleModel = obj as MainArticleModel;
            mainArticleModel.ID = Guid.NewGuid();
            mainArticleModel.CreateUser = HttpContext.Current.User.Identity.Name;
            mainArticleModel.PublichDate = DateTime.Now;
            mainArticleModel.ReplyCount = 0;
            db.MainArticles.Add(mainArticleModel);
            await dataSave.Save(db);
        }

        async public Task Update(object obj)
        {
            ArticleAndReplyModel replyModel = obj as ArticleAndReplyModel;
            replyModel.reply.ID = Guid.NewGuid();
            replyModel.reply.CreateUser = HttpContext.Current.User.Identity.Name;
            replyModel.reply.PublichDate = DateTime.Now;
            MainArticleModel article = await db.MainArticles.FindAsync(replyModel.reply.ArticleID);
            article.ReplyCount = article.replyArticles.ToList().Count() + 1;
            db.Replies.Add(replyModel.reply);
            await dataSave.Save(db);
        }
    }
}