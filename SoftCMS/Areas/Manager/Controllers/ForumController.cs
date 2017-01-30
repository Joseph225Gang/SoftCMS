using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftCMS.Models;
using SoftCMS.IDatabaseRepository;

namespace SoftCMS.Areas.Manager.Controllers
{
    [Authorize(Users = "wang@mail.com")]
    public class ForumController : Controller
    {
        private SoftContext db = new SoftContext();
        private IDatabaseRepository.IDatabaseRepository repository = null;

        public ForumController()
        {
            this.repository = new ForumRepository();
        }

        // GET: Manager/Forum
        public async Task<ActionResult> Index()
        {
            var categories = db.Categories.Include(f => f.MainThemes);
            return View(await categories.ToListAsync());
        }

        // GET: Manager/Forum/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.MainThemes, "ID", "ContentText");
            return View();
        }

        // POST: Manager/Forum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TopicID,ContentText,PublichDate,CreateUser")] Forum forum)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.Insert(forum);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "無法儲存，請聯絡網站管理員");
            }

            ViewBag.TopicID = new SelectList(db.MainThemes, "ID", "ContentText", forum.TopicID);
            return View(forum);
        }

        // GET: Manager/Forum/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = await db.Categories.FindAsync(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.MainThemes, "ID", "ContentText", forum.TopicID);
            return View(forum);
        }

        // POST: Manager/Forum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> Edit([Bind(Include = "ID,TopicID,ContentText,PublichDate,CreateUser")] Forum forum)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.Update(forum);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "無法儲存，請聯絡網站管理員");
            }
            ViewBag.TopicID = new SelectList(db.MainThemes, "ID", "ContentText", forum.TopicID);
            return View(forum);
        }

        // GET: Manager/Forum/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = await db.Categories.FindAsync(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: Manager/Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await repository.Delete(id);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "無法儲存，請聯絡網站管理員");
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
