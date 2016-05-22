using NaughtyFamily.DBconn;
using NaughtyFamily.Models.ViewModels;
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
                List<PetInfo> petInfos = new List<PetInfo>();
                petInfos =
                    (from p in dbConn.PetInfo
                     orderby p.PId descending
                     select p).ToList();

                List<vPetInfo> vpetInfos = new List<vPetInfo>();
                foreach (PetInfo petInfo in petInfos)
                {
                    vPetInfo vpetInfo = new vPetInfo(petInfo);
                    vpetInfos.Add(vpetInfo);
                }
                ViewBag.petInfos = vpetInfos;
            }
            return View();
        }

        public ActionResult system()
        {
            return View();
        }
    }
}