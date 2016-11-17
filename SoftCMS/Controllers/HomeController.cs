using PagedList;
using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS.Controllers
{
    public class HomeController : Controller
    {
        private SoftContext softContext = new SoftContext();

        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var articles = softContext.MainArticles.AsQueryable();
            var result = articles.OrderBy(num => num.PublichDate).ToPagedList(page, pageSize);
            return View(result);
        }
    }
}