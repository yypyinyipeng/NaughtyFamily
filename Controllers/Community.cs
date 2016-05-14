using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaughtyFamily.Controllers
{
    public class CommunityController : Controller
    {
        public ActionResult community()
        {
            ViewBag.Title = "Community";
            return View();
        }
    }
}