using PagedList;
using SoftCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS.Controllers
{
    public class HomeController : Controller
    {
        private SoftContext softContext = new SoftContext();

        public ActionResult Index()
        {
            return View(softContext.MainThemes.ToList());
        }
    }
}