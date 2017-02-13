using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SoftCMS.IDatabaseRepository
{
    public class SoftContextInit : DbInit
    {
        async public Task Save(DbContext obj)
        {
            SoftContext db = obj as SoftContext;
            await db.SaveChangesAsync();
        }
    }
}