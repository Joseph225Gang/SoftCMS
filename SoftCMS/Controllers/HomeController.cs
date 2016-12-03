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

        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            var articles = softContext.MainArticles.AsQueryable();
            if(string.IsNullOrWhiteSpace(searchString) == false)
            {
                articles = articles.Where(d => d.Subject.Contains(searchString));
            }
            var result = articles.OrderBy(num => num.PublichDate).ToPagedList(page, pageSize);
            return View(result);
        }
    }
}