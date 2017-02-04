using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoftCMS.IDatabaseRepository
{
    interface DataBaseInitialize
    {
        Task Save(DbContext obj);
    }
}