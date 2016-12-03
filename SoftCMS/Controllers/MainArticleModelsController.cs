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

namespace SoftCMS.Controllers
{
    [Authorize]
    public class MainArticleModelsController : Controller
    {
        private SoftContext db = new SoftContext();

        // GET: MainArticleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainArticleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Subject,ContentText")] MainArticleModel mainArticleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mainArticleModel.ID = Guid.NewGuid();
                    mainArticleModel.CreateUser = User.Identity.Name;
                    mainArticleModel.PublichDate = DateTime.Now;
                    mainArticleModel.ReplyCount = 0;
                    db.MainArticles.Add(mainArticleModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
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
        public ActionResult Details(ArticleAndReplyModel replyModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string subject = TempData["subject"].ToString();
                    replyModel.reply.ID = Guid.NewGuid();
                    replyModel.reply.ArticleID = db.MainArticles.Where(u => u.Subject.Equals(subject)).SingleOrDefault().ID;
                    replyModel.reply.ArticelMaker = db.MainArticles.Where(u => u.ID.Equals(replyModel.reply.ArticleID)).SingleOrDefault().CreateUser;
                    replyModel.reply.CreateUser = User.Identity.Name;
                    replyModel.reply.PublichDate = DateTime.Now;
                    MainArticleModel article = db.MainArticles.Find(replyModel.reply.ArticleID);
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
