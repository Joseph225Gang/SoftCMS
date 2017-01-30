using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftCMS.Models;

namespace SoftCMS.Controllers
{
    public class ForumController : Controller
    {
        private SoftContext db = new SoftContext();

        [HttpGet]
        public ActionResult Browse(string name)
        {
            var categories = db.Categories.Include(f => f.MainThemes).Where(f => f.MainThemes.ContentText.Equals(name));
            return View(categories.ToList());
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
