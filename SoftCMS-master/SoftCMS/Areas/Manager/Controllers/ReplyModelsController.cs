using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftCMS.Models;
using System.Threading.Tasks;
using SoftCMS.IDatabaseRepository;

namespace SoftCMS.Areas.Manager.Controllers
{
    public class ReplyModelsController : Controller
    {
        private SoftContext db = new SoftContext();
        private IDatabaseRepository.IDatabaseRepository repository = null;

        public ReplyModelsController()
        {
            this.repository = new ReplyModelRepository(db);
        }

        // GET: Manager/ReplyModels
        public async Task<ActionResult> Index()
        {
            var replies = db.Replies.Include(r => r.mainArticle);
            return View(await replies.ToListAsync());
        }

        // GET: Manager/ReplyModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyModel replyModel = db.Replies.Find(id);
            if (replyModel == null)
            {
                return HttpNotFound();
            }
            return View(replyModel);
        }

        // POST: Manager/ReplyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                repository.Delete(id);
                db.SaveChanges();
            }
            catch(DataException)
            {
                return RedirectToAction("DataError", "Error", new { area = "",message = "刪除錯誤" });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
