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
        private DbInit dbSave = new SoftContextInit();
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