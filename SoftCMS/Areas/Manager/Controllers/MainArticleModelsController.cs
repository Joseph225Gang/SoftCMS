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
    [Authorize(Users ="wang@mail.com")]
    public class MainArticleModelsController : Controller
    {
        private SoftContext db = new SoftContext();
        private IDatabaseRepository.IDatabaseRepository repository = null;

        public MainArticleModelsController()
        {
            this.repository = new MainArticleModelRepository(db);
        }

        // GET: Manager/MainArticleModels
        public async Task<ActionResult> Index()
        {
            return View(await db.MainArticles.ToListAsync());
        }

        // GET: Manager/MainArticleModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainArticleModel mainArticleModel = db.MainArticles.Find(id);
            if (mainArticleModel == null)
            {
                return HttpNotFound();
            }
            return View(mainArticleModel);
        }

        // POST: Manager/MainArticleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
               await repository.Delete(id);
            }
            catch(DataException)
            {
                return RedirectToAction("DataError", "Error",new { area="",message = "文章刪除錯誤" });
            }
            return RedirectToAction("Index");
        }

        // GET: Manager/MainArticleModels1/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainArticleModel mainArticleModel = await db.MainArticles.FindAsync(id);
            if (mainArticleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ForumID = new SelectList(db.Categories, "ID", "ContentText", mainArticleModel.ForumID);
            return View(mainArticleModel);
        }

        // POST: Manager/MainArticleModels1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "ForumID,Subject,ContentText")] MainArticleModel mainArticleModel)
        {
            if (ModelState.IsValid)
            {
                await repository.Update(mainArticleModel);
                return RedirectToAction("Index");
            }
            ViewBag.ForumID = new SelectList(db.Categories, "ID", "ContentText", mainArticleModel.ForumID);
            return View(mainArticleModel);
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
