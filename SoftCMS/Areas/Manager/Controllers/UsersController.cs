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
    [Authorize(Users = "wang@mail.com")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IDatabaseRepository.IDbDelete repository = null;

        public UsersController()
        {
            this.repository = new UserRepository(db);
        }

        // GET: Manager/Users
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.Where(u => u.NickName != "wang223").ToListAsync());
        }

        // GET: Manager/Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Manager/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                Guid userId = new Guid(id);
                await repository.Delete(userId);
            }
            catch(DataException)
            {
                return RedirectToAction("DataError", "Error", new { area = "",message = "用戶刪除錯誤" });
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
