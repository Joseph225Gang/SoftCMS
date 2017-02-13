using SoftCMS.Models;
using SoftCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS.IDatabaseRepository
{
    public class MainArticleModelRepository : IDatabaseRepository
    {
        private DbInit dbSave = new SoftContextInit();
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
            MainArticleModel mainArticleModel = obj as MainArticleModel;
            await dbSave.Save(db);
        }
    }
}