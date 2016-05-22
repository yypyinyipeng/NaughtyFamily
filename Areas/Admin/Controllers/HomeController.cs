using NaughtyFamily.DBconn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaughtyFamily.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.currentTime = DateTime.Now;
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult insert()
        {
            return View();
        }

        public ActionResult design()
        {
            using (DbConn dbConn = new DbConn())
            {
                List<PetInfo> perInfos = new List<PetInfo>();
                perInfos =
                    (from p in dbConn.PetInfo
                     orderby p.PId descending
                     select p).ToList();

                ViewBag.perInfos = perInfos;
            }
            return View();
        }

        public ActionResult system()
        {
            return View();
        }
    }
}