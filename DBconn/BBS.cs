using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NaughtyFamily.DBconn
{
    public class BBS
    {
        [Key]
        public int BId { get; set; }

        public string title { get; set; }   //题目

        public string content { get; set; }   //  内容

        public DateTime release_time { get; set; }  //发布时间

        public enum PostType {普通, 置顶, 废弃}  //用户类型 普通  0    置顶  1   废弃  2

        public PostType post_type { get; set; } 

        public int visits { get; set; }   // 访问量

        public int writer_id { get; set; }   // 作者Id   外键于UserInfo   

        [ForeignKey("writer_id")]
        public virtual UserInfo UserInfo { get; set; }

    }
}