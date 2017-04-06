using Microsoft.AspNet.Identity;
using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;

namespace SoftCMS.IDatabaseRepository
{
    public class ForumRepository : IDatabaseRepository
    {
<<<<<<< HEAD
        private DataBaseInitialize dbSave = new SoftContextInitialize();
=======
        private DbInit dbSave = new SoftContextInit();
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        private SoftContext db = null;

        public ForumRepository()
        {
            db = new SoftContext();
        }

        public ForumRepository(SoftContext db)
        {
            this.db = db;
        }

        async public Task Delete(Guid id)
        {
             Forum forum = await db.Categories.FindAsync(id);
             db.Categories.Remove(forum);
             await dbSave.Save(db);
        }

        async public Task Insert(object obj)
        {
            Forum forum = obj as Forum;
            forum.ID = Guid.NewGuid();
            forum.CreateUser = HttpContext.Current.User.Identity.Name;
            forum.PublichDate = DateTime.Now;
            db.Categories.Add(forum);
            await dbSave.Save(db);
        }

        async public Task Update(object obj)
        {
            Forum forum = obj as Forum;
            db.Entry(forum).State = EntityState.Modified;
            await dbSave.Save(db);
        }
    }
}