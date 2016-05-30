using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NaughtyFamily.DBconn
{
    public class Reply_BBS
    {
        [Key]
        public int BRId { get; set; }

        public string content { get; set; }  //评论内容

        public DateTime release_time { get; set; }  // 发布时间

        public int writer_id { get; set; }  //回复作者Id  外键于UserInfo

        [ForeignKey("writer_id")]
        public virtual UserInfo UserInfo { get; set; }

        public int bbs_id { get; set; }    //父级帖子  Id  外键于  BBS

        [ForeignKey("bbs_id")]
        public virtual BBS BBS { get; set; }
    }
}