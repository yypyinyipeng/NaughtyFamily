using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NaughtyFamily.DBconn
{
    public class PetInfo
    {
        [Key]
        public int PId { get; set; }

        public string pet_name { get; set; }   //宠物名字

        public string pet_pic_url { get; set; }   // 宠物图片   路径

        public int pet_type { get; set; }   //物种类型

        [ForeignKey("pet_type")]
        public virtual PetType PetType { get; set; }

        public enum PGenderType {雄,雌 }   //宠物性别  雄性  0    雌性  1

        public int pet_age { get; set; }   //宠物年龄

        public string pet_message { get; set; }   //宠物信息

        public DateTime update_date { get; set; }

        public int owner_id { get; set; }   //宠物主人的Id   外键于userinfo

        [ForeignKey("owner_id")]
        public virtual UserInfo UserInfo { get; set; }
    }
}