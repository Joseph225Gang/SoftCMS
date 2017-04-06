using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult ErrorFound()
        {
            return View();
        }

        public ActionResult DataError(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}