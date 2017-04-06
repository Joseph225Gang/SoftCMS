using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SoftCMS.IDatabaseRepository
{
<<<<<<< HEAD
    public class SoftContextInitialize : DataBaseInitialize
=======
    public class SoftContextInit : DbInit
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
    {
        async public Task Save(DbContext obj)
        {
            SoftContext db = obj as SoftContext;
            await db.SaveChangesAsync();
        }
    }
}