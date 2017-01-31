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
        private ApplicationDbContext db = null;
        public UserRepository()
        {
            db = new ApplicationDbContext();
        }

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Browse()
        {
            throw new NotImplementedException();
        }

        async public Task Delete(Guid id)
        {
            string guid = id.ToString();
            ApplicationUser applicationUser = db.Users.Find(guid);
            db.Users.Remove(applicationUser);
            await Save();
        }

        public Task Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public Task Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}