using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoftCMS.IDatabaseRepository
{
    public class UserRepository : IDatabaseRepository
    {
        private DataBaseInitialize dbSave = new ApplicationUserInitialize();
        private ApplicationDbContext db = null;

        public UserRepository()
        {
            db = new ApplicationDbContext();
        }

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        async public Task Delete(Guid id)
        {
            string guid = id.ToString();
            ApplicationUser applicationUser = db.Users.Find(guid);
            db.Users.Remove(applicationUser);
            await dbSave.Save(db);
        }

        public Task Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}