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
