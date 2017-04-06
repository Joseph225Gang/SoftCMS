using SoftCMS.Models;
<<<<<<< HEAD
=======
using SoftCMS.ViewModel;
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoftCMS.IDatabaseRepository
{
    public class ReplyModelRepository : IDatabaseRepository
    {
<<<<<<< HEAD
        private DataBaseInitialize dbSave = new SoftContextInitialize();
=======
        private DbInit dbSave = new SoftContextInit();
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        private SoftContext db = null;

        public ReplyModelRepository()
        {
            db = new SoftContext();
        }

        public ReplyModelRepository(SoftContext db)
        {
            this.db = db;
        }

        async public Task Delete(Guid id)
        {
            ReplyModel replyModel = db.Replies.Find(id);
            db.Replies.Remove(replyModel);
            await dbSave.Save(db);
        }

<<<<<<< HEAD
        public Task Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(object obj)
        {
            throw new NotImplementedException();
=======
        public async Task Insert(object obj)
        {
            ArticleAndReplyModel replyModel = obj as ArticleAndReplyModel;
            replyModel.reply.ID = Guid.NewGuid();
            replyModel.reply.CreateUser = HttpContext.Current.User.Identity.Name;
            replyModel.reply.PublichDate = DateTime.Now;
            MainArticleModel article = await db.MainArticles.FindAsync(replyModel.reply.ArticleID);
            article.ReplyCount = article.replyArticles.ToList().Count() + 1;
            db.Replies.Add(replyModel.reply);
            await dbSave.Save(db);
        }

        public async Task Update(object obj)
        {
            ReplyModel replyModel = obj as ReplyModel;
            await dbSave.Save(db);
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        }
    }
}