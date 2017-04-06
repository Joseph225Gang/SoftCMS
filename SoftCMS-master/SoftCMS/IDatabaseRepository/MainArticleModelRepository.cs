using SoftCMS.Models;
using SoftCMS.ViewModel;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Data.Entity;
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS.IDatabaseRepository
{
    public class MainArticleModelRepository : IDatabaseRepository
    {
<<<<<<< HEAD
        private DataBaseInitialize dbSave = new SoftContextInitialize();
=======
        private DbInit dbSave = new SoftContextInit();
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
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
            await dbSave.Save(db);
        }

        async public Task Insert(object obj)
        {
            MainArticleModel mainArticleModel = obj as MainArticleModel;
            mainArticleModel.ID = Guid.NewGuid();
            mainArticleModel.CreateUser = HttpContext.Current.User.Identity.Name;
            mainArticleModel.PublichDate = DateTime.Now;
            mainArticleModel.ReplyCount = 0;
            db.MainArticles.Add(mainArticleModel);
            await dbSave.Save(db);
        }

        async public Task Update(object obj)
        {
<<<<<<< HEAD
            ArticleAndReplyModel replyModel = obj as ArticleAndReplyModel;
            replyModel.reply.ID = Guid.NewGuid();
            replyModel.reply.CreateUser = HttpContext.Current.User.Identity.Name;
            replyModel.reply.PublichDate = DateTime.Now;
            MainArticleModel article = await db.MainArticles.FindAsync(replyModel.reply.ArticleID);
            article.ReplyCount = article.replyArticles.ToList().Count() + 1;
            db.Replies.Add(replyModel.reply);
=======
            MainArticleModel mainArticleModel = obj as MainArticleModel;
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
            await dbSave.Save(db);
        }
    }
}