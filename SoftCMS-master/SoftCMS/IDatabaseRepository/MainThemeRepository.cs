using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoftCMS.IDatabaseRepository
{
    public class MainThemeRepository : IDatabaseRepository
    {
<<<<<<< HEAD
        private DataBaseInitialize dbSave = new SoftContextInitialize();
=======
        private DbInit dbSave = new SoftContextInit();
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        private SoftContext db = null;

        public MainThemeRepository()
        {
            db = new SoftContext();
        }

        public MainThemeRepository(SoftContext db)
        {
            this.db = db;
        }

        async public Task Delete(Guid id)
        {
            MainThemes mainThemes = await db.MainThemes.FindAsync(id);
            db.MainThemes.Remove(mainThemes);
            await dbSave.Save(db);
        }

        async public Task Insert(object obj)
        {
            MainThemes mainThemes = obj as MainThemes;
            mainThemes.ID = Guid.NewGuid();
            mainThemes.CreateUser = HttpContext.Current.User.Identity.Name;
            mainThemes.PublichDate = DateTime.Now;
            db.MainThemes.Add(mainThemes);
            await dbSave.Save(db);
        }

        async public Task Update(object obj)
        {
            MainThemes mainThemes = obj as MainThemes;
            db.Entry(mainThemes).State = EntityState.Modified;
            await dbSave.Save(db);
        }
    }
}