using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftCMS.Models;

namespace SoftCMS.Areas.Manager.Controllers
{
    public class ReplyModelsController : Controller
    {
        private SoftContext db = new SoftContext();

        // GET: Manager/ReplyModels
        public ActionResult Index()
        {
            var replies = db.Replies.Include(r => r.mainArticle);
            return View(replies.ToList());
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
            ReplyModel replyModel = db.Replies.Find(id);
            db.Replies.Remove(replyModel);
            db.SaveChanges();
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
