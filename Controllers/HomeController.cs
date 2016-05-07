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
        public ActionResult Index(int page = 0)
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

                //ViewBag.petInfoes = petInfoes;
                return Json(ajaxModel);
            }
        }
    }
}