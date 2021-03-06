﻿using NaughtyFamily.DBconn;
using NaughtyFamily.Models.ViewModels;
using NaughtyFamily.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NaughtyFamily.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.currentTime = DateTime.Now;
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string username, string pwd)
        {
            DbConn dbConn = new DbConn();

            UserInfo userInfo = new UserInfo();

            string name = username;
            string password = Encryt.GetMD5(pwd.Trim());
            dbConn.UserInfo.Where(u => (u.user_name == name && u.pwd == password));  //加权限验证
            if (dbConn.UserInfo.Count() != 0)
            {
                FormsAuthentication.SetAuthCookie(name, false);
                ViewBag.currentAdminUser = HttpContext.User.Identity.Name;
                return Redirect("/Admin/Home/Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult insert(int typeId, string name, int age, string smalling, string content)
        {
            DbConn dbConn = new DbConn();

            PetInfo petInfo = new PetInfo();
            UserInfo userInfo = new UserInfo();

            string userName = HttpContext.User.Identity.Name;
            dbConn.UserInfo.Where(u => (u.user_name == userName));

            int ownerId = userInfo.UId;

            petInfo.pet_type = typeId;
            petInfo.pet_name = name;
            petInfo.pet_age = age;
            petInfo.pet_pic_url = "";
            petInfo.pet_message = content;
            petInfo.owner_id = ownerId;
            dbConn.PetInfo.Add(petInfo);
            dbConn.SaveChanges();

            return Redirect("/Admin/Home/design");
        }

        [HttpGet]
        public ActionResult design()
        {
            DbConn dbConn = new DbConn();

            List<PetInfo> petInfos = new List<PetInfo>();
            dbConn.PetInfo.Select(p => p).ToList();
            petInfos =
                (from p in dbConn.PetInfo
                 orderby p.PId descending
                 select p).ToList();

            int infoCount = petInfos.Count();
            List<vPetInfo> vpetInfos = new List<vPetInfo>();
            foreach (PetInfo petInfo in petInfos)
            {
                vPetInfo vpetInfo = new vPetInfo(petInfo);
                vpetInfos.Add(vpetInfo);
            }
            ViewBag.petInfos = vpetInfos;
            ViewBag.infoCount = infoCount;
            return View();
        }

        [HttpGet]
        public ActionResult designDelete(int id)
        {
            DbConn dbConn = new DbConn();

            PetInfo petInfo = new PetInfo();
            int Id = id;
            petInfo =
                (from p in dbConn.PetInfo
                 where p.PId == Id
                 select p).SingleOrDefault();
            dbConn.PetInfo.Remove(petInfo);
            dbConn.SaveChanges();
            return Redirect("/Admin/Home/design");
        }

        [HttpGet]
        public ActionResult system()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Admin/Home/Index");
        }
    }
}