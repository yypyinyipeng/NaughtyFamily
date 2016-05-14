using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaughtyFamily.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult about()
        {
            ViewBag.Title = "About";
            return View();
        }
    }
}