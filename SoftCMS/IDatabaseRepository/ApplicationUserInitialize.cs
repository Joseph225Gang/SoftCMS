using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SoftCMS.IDatabaseRepository
{
    public class ApplicationUserInitialize : DataBaseInitialize
    {
        async public Task Save(DbContext obj)
        {
            ApplicationDbContext db = obj as ApplicationDbContext;
            await db.SaveChangesAsync();
        }
    }
}