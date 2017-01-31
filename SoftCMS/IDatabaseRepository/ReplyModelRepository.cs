using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoftCMS.IDatabaseRepository
{
    public class ReplyModelRepository : IDatabaseRepository
    {
        private SoftContext db = null;

        public ReplyModelRepository()
        {
            db = new SoftContext();
        }

        public ReplyModelRepository(SoftContext db)
        {
            this.db = db;
        }

        public void Browse()
        {
            throw new NotImplementedException();
        }

        async public Task Delete(Guid id)
        {
            ReplyModel replyModel = db.Replies.Find(id);
            db.Replies.Remove(replyModel);
            await Save();
        }

        public Task Insert(object obj)
        {
            throw new NotImplementedException();
        }

        async public Task Save()
        {
            await db.SaveChangesAsync();
        }

        public Task Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}