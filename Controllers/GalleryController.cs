using NaughtyFamily.DBconn;
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
            DbConn dbConn = new DbConn();

            List<BBS> bbs = new List<BBS>();
            bbs =
                (from b in dbConn.BBS
                 orderby b.BId descending
                 select b).ToList();

            ViewBag.bbs = bbs;
            ViewBag.Title = "Gallery";
            return View();
        }
    }
}