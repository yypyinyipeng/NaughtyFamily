using NaughtyFamily.DBconn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaughtyFamily.Models.DateModels;
using NaughtyFamily.Utility;
using System.Web.Security;

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

        /// <summary>
        /// Index瀑布流加载内容
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int page = 0)
        {
            DbConn dbConn = new DbConn();

            List<PetInfo> petInfoes = new List<PetInfo>();
            int index = page * 4;
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

        /// <summary>
        /// 宠物详细内容  Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            DbConn dbConn = new DbConn();
            PetInfo petInfo = new PetInfo();

            petInfo =
                (from p in dbConn.PetInfo
                 where p.PId == id
                 select p).SingleOrDefault();

            ViewBag.petInfoes = petInfo;
            return View();
        }

        /// <summary>
        /// 检测用户名是否已被使用
        /// </summary>
        /// <param name="registerName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult checkRegister(string registerName)
        {
            DbConn dbConn = new DbConn();

            UserInfo userInfo = new UserInfo();
            string name = registerName.Trim();
            userInfo =
                (from u in dbConn.UserInfo
                 where u.user_name == name
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

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerName"></param>
        /// <param name="registerPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult userRegister(string registerName, string registerPwd)
        {
            DbConn dbConn = new DbConn();

            UserInfo userInfo = new UserInfo();
            string name = registerName.Trim(); ;
            string pwd = Encryt.GetMD5(registerPwd.Trim());
            AjaxModel ajaxModel = new AjaxModel();
            try
            {
                userInfo.user_name = name;
                userInfo.pwd = pwd;
                userInfo.create_time = DateTime.Now;
                dbConn.UserInfo.Add(userInfo);
                int res = dbConn.SaveChanges();
                if (res != 0)
                {
                    ajaxModel.Statu = "OK";
                    ajaxModel.Msg = "注册成功!";
                }
                else
                {
                    ajaxModel.Statu = "NOK";
                    ajaxModel.Msg = "注册失败!";
                }
            }
            catch
            {
                ajaxModel.Statu = "error";
                ajaxModel.Msg = "注册失败!";
            }
            return Json(ajaxModel);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult userSignIn(string signinName, string signinPwd)
        {
            DbConn dbConn = new DbConn();
            UserInfo userInfo = new UserInfo();
            string name = signinName.Trim();
            string pwd = Encryt.GetMD5(signinPwd.Trim());
            AjaxModel ajaxModel = new AjaxModel();
            try
            {
                userInfo =
                    (from u in dbConn.UserInfo
                     where u.user_name == name
                     select u).FirstOrDefault();
                if (userInfo == null)
                {
                    ajaxModel.Statu = "NOK";
                    ajaxModel.Msg = "该用户还未注册";
                }
                else
                {
                    if (userInfo.pwd == pwd)
                    {
                        ajaxModel.Statu = "OK";
                        ajaxModel.Msg = "登陆成功!";
                        FormsAuthentication.SetAuthCookie(name, false);
                        ViewBag.currentUser = HttpContext.User.Identity.Name;
                        //if (ModelState.IsValid)  //配套@Html.ValidationSummary()
                        //{

                        //}
                    }
                    else
                    {
                        ajaxModel.Statu = "NOK";
                        ajaxModel.Msg = "密码错误，请重新输入";
                    }
                }
            }
            catch
            {
                ajaxModel.Statu = "error";
                ajaxModel.Msg = "登陆失败!";
            }
            return Json(ajaxModel);
        }

        /// <summary>
        /// 登陆注销
        /// </summary>
        /// <returns></returns>
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 显示用户详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult userInfoDisplay(string userName)
        {
            using (DbConn dbConn = new DbConn())
            {
                UserInfo userInfo = new UserInfo();
                userInfo =
                    (from u in dbConn.UserInfo
                     where u.user_name == userName
                     select u).SingleOrDefault();
                ViewBag.userInfos = userInfo;
            }
            return View();
        }

    }
}