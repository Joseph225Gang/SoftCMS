using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoftCMS.IDatabaseRepository
{
<<<<<<< HEAD
    interface DataBaseInitialize
=======
    interface DbInit
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
    {
        Task Save(DbContext obj);
    }
}