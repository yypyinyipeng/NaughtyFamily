using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaughtyFamily.DBconn
{  
     public class UserInfo
    {
        [Key]   
        public int UId { get; set; }

        public string user_name { get; set; }

        public string pwd { get; set; }

        public int age { get; set; }

        public enum GenderType { 男,女 }   //男  0   女  1

        public GenderType gender { get; set; }

        public string email { get; set; }

        public string telephone_number { get; set; }

        public string address { get; set; }

        public enum UserType { 消费者,商家,管理员 }   //消费者 0   商家  1    管理员   2

        public UserType user_type { get; set; }

        public DateTime create_time { get; set; }  //用户创建日期

    }
}