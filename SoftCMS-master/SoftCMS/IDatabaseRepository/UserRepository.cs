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
<<<<<<< HEAD
        private DataBaseInitialize dbSave = new ApplicationUserInitialize();
=======
        private DbInit dbSave = new ApplicationUserInit();
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
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
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            throw new NotImplementedException("請到Account/Register頁面註冊");
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        }

        public Task Update(object obj)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            throw new NotImplementedException("用戶資料不可修改");
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        }
    }
}