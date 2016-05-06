using NaughtyFamily.DBconn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaughtyFamily.Models.DateModels;

namespace NaughtyFamily.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (DbConn dbConn = new DbConn())
            {
                //UserInfo userInfo = new UserInfo();
                //userInfo.user_name = "yipengy";
                //userInfo.age = 22;
                //userInfo.email = "18845296347@163.com";
                //userInfo.gender = 0;
                //userInfo.telephone_number = "18845296347";
                //userInfo.create_time = DateTime.Now;
                //dbConn.Database.Initialize(true);
                //dbConn.UserInfo.Add(userInfo);

                //dbConn.SaveChanges();

                List<PetInfo> petInfoes = new List<PetInfo>();
                petInfoes =
                    (from p in dbConn.PetInfo
                     orderby p.PId descending
                     select p).Take(4).ToList();

                ViewBag.petInfoes = petInfoes;


            }
                return View();
        }
    }
}