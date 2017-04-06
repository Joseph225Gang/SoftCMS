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

<<<<<<< HEAD
=======
        // GET: Manager/ReplyModels1/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyModel replyModel = await db.Replies.FindAsync(id);
            if (replyModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.MainArticles, "ID", "Subject", replyModel.ArticleID);
            return View(replyModel);
        }

        // POST: Manager/ReplyModels1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContentText")] ReplyModel replyModel)
        {
            if (ModelState.IsValid)
            {
                await repository.Update(replyModel);
                return RedirectToAction("Index");
            }
            return View(replyModel);
        }

>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
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
