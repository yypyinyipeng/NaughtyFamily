﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaughtyFamily.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }
    }
}