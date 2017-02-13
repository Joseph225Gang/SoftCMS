using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftCMS.Models;
using SoftCMS.ViewModel;
using System.Threading.Tasks;
using PagedList;
using SoftCMS.IDatabaseRepository;

namespace SoftCMS.Controllers
{
    [Authorize]
    public class MainArticleModelsController : Controller
    {
        private SoftContext db = new SoftContext();
        private IDatabaseRepository.IDatabaseRepository repository = null;

        public MainArticleModelsController()
        {
            this.repository = new MainArticleModelRepository(db);
        }

        public ActionResult Index(string title, int page = 1, int pageSize = 2)
        {
            var articles = db.MainArticles.Where(u => u.Forum.ContentText.Equals(title)).AsQueryable();
            ViewBag.Title = title;
            var result = articles.OrderBy(num => num.PublichDate).ToPagedList(page, pageSize);
            return View(result);
        }

        // GET: MainArticleModels/Create
        public ActionResult Create(string title)
        {
            ViewBag.Theme = title;
            return View();
        }

        // POST: MainArticleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "Subject,ContentText")] MainArticleModel mainArticleModel)
        {
            string forum = TempData["Forum"].ToString();
            try
            {
                if (ModelState.IsValid)
                {
                    mainArticleModel.Forum = db.Categories.Where(c => c.ContentText.Equals(forum)).First();
                    await repository.Insert(mainArticleModel);
                    return RedirectToAction("Index", "MainArticleModels",new { title = forum });
                }
            }
            catch(DataException)
            {
                return RedirectToAction("DataError", "Error", new { message = "儲存錯誤" });
            }

            return View(mainArticleModel);
        }

        // GET: Course/Details/5
        [AllowAnonymous]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainArticleModel article = db.MainArticles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ArticleAndReplyModel articleModel = new ArticleAndReplyModel();
            articleModel.article = article;
            articleModel.reply = new ReplyModel();
            return View(articleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(ArticleAndReplyModel replyModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string subject = TempData["subject"].ToString();
                    replyModel.reply.ArticleID = db.MainArticles.Where(u => u.ID.ToString().Equals(subject)).Single().ID;
                    replyModel.reply.ArticelMaker = db.MainArticles.Where(u => u.ID.Equals(replyModel.reply.ArticleID)).SingleOrDefault().CreateUser;
                    repository = new ReplyModelRepository(db);
                    await repository.Insert(replyModel);
                    return RedirectToAction("Details", "MainArticleModels", new { id = replyModel.reply.ArticleID });
                }
            }
            catch(DataException)
            {
                return RedirectToAction("DataError", "Error", new { message = "用戶儲存錯誤"});
            }
            return View(replyModel);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID,ForumID,Subject,ReplyCount,ContentText,PublichDate,CreateUser")] MainArticleModel mainArticleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainArticleModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
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
