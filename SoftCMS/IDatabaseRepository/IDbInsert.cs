using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCMS.IDatabaseRepository
{
    public interface IDbInsert
    {
        Task Insert(Object obj);
    }
}
