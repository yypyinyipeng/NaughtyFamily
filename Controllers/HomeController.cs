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
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }

        [HttpPost]
        public ActionResult Index(int page = 0)
        {
            DbConn dbConn = new DbConn();

            int index = page * 4;
            List<PetInfo> petInfoes = new List<PetInfo>();
            petInfoes =
                (from p in dbConn.PetInfo
                 orderby p.PId descending
                 select p).Skip(index).Take(4).ToList();

            AjaxModel ajaxModel = new AjaxModel();
            try
            {
                if (petInfoes.Count == 0)
                {
                    ajaxModel.Data = "";
                    ajaxModel.Statu = "end";
                    ajaxModel.Msg = "没有更多内容了！";
                }
                else
                {
                    ajaxModel.Data = petInfoes;
                    ajaxModel.Statu = "OK";
                    ajaxModel.Msg = "加载成功!";
                }
            }
            catch
            {
                ajaxModel.Data = "";
                ajaxModel.Statu = "error";
                ajaxModel.Msg = "加载失败！";
            }
            return Json(ajaxModel);
        }

        [HttpPost]
        public ActionResult userRegister(string registerName)
        {
            DbConn dbConn = new DbConn();

            string name = registerName;
            UserInfo userInfo = new UserInfo();
            userInfo =
                (from u in dbConn.UserInfo
                 where u.user_name.Equals(name)
                 select u
                ).FirstOrDefault();

            AjaxModel ajaxModel = new AjaxModel();
            try
            {
                if (userInfo == null)
                {
                    ajaxModel.Statu = "OK";
                    ajaxModel.Msg = "该用户名可以使用";
                }
                else
                {
                    ajaxModel.Statu = "NOK";
                    ajaxModel.Msg = "该用户名已被使用";
                }
            }
            catch
            {
                ajaxModel.Statu = "error";
                ajaxModel.Msg = "验证失败";
            }
            return Json(ajaxModel);
        }
    }
}