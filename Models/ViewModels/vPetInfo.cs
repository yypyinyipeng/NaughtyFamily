using NaughtyFamily.DBconn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaughtyFamily.Models.ViewModels
{
    public class vPetInfo
    {
        public int PId { get; set; }

        public string pet_name { get; set; }   //宠物名字

        public string pet_pic_url { get; set; }   // 宠物图片   路径

        public int pet_age { get; set; }   //宠物年龄

        public string pet_message { get; set; }   //宠物信息

        public DateTime update_date { get; set; }

        public int owner_id { get; set; }   //宠物主人的Id   外键于userinfo

        public string pet_type_str { get; set; }  //宠物类型  string类型

        public string pet_gender { get; set; }  //宠物性别  string 类型

        public vPetInfo(PetInfo model)
        {
            using (DbConn dbConn = new DbConn())
            {
                pet_type_str = (from pt in dbConn.PetType where pt.PTId == model.pet_type select pt.type).SingleOrDefault();
            }
            PId = model.PId;
            pet_name = model.pet_name;
            pet_pic_url = model.pet_pic_url;
            pet_age = model.pet_age;
            pet_message = model.pet_message;
            update_date = model.update_date;
            owner_id = model.owner_id;
            if (model.pet_gender == 0)
                pet_gender = "雄性";
            else
                pet_gender = "雌性";

        }
    }
}