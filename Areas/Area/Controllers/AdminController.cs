﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaughtyFamily.Areas.Admin.Controllers
{
    public class AdminController : Controller
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
            return View();
        }

        public ActionResult system()
        {
            return View();
        }
    }
}