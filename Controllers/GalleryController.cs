using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaughtyFamily.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult gallery()
        {
            ViewBag.Title = "Gallery";
            return View();
        }
    }
}