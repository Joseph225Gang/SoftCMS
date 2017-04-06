using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCMS.IDatabaseRepository
{
    public interface IDatabaseRepository
    {
        Task Insert(Object obj);
        Task Update(Object obj);
        Task Delete(Guid id);
    }
}
