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

namespace SoftCMS.Controllers
{
    [Authorize]
    public class MainArticleModelsController : Controller
    {
        private SoftContext db = new SoftContext();

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
        public async Task<ActionResult> Create([Bind(Include = "Subject,ContentText")] MainArticleModel mainArticleModel)
        {
            string forum = TempData["Forum"].ToString();
            try
            {
                if (ModelState.IsValid)
                {
                    mainArticleModel.Forum = db.Categories.Where(c => c.ContentText.Equals(forum)).First();
                    mainArticleModel.ID = Guid.NewGuid();
                    mainArticleModel.CreateUser = User.Identity.Name;
                    mainArticleModel.PublichDate = DateTime.Now;
                    mainArticleModel.ReplyCount = 0;
                    db.MainArticles.Add(mainArticleModel);
                    await db.SaveChangesAsync();
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
                    replyModel.reply.ID = Guid.NewGuid();
                    replyModel.reply.ArticleID = db.MainArticles.Where(u => u.ID.ToString().Equals(subject)).Single().ID;
                    replyModel.reply.ArticelMaker = db.MainArticles.Where(u => u.ID.Equals(replyModel.reply.ArticleID)).SingleOrDefault().CreateUser;
                    replyModel.reply.CreateUser = User.Identity.Name;
                    replyModel.reply.PublichDate = DateTime.Now;
                    MainArticleModel article = await db.MainArticles.FindAsync(replyModel.reply.ArticleID);
                    article.ReplyCount = article.replyArticles.ToList().Count() + 1;
                    db.Replies.Add(replyModel.reply);
                    db.SaveChanges();
                    return RedirectToAction("Details", "MainArticleModels", new { id = replyModel.reply.ArticleID });
                }
            }
            catch(DataException)
            {
                return RedirectToAction("DataError", "Error", new { message = "用戶儲存錯誤"});
            }
            return View(replyModel);
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
