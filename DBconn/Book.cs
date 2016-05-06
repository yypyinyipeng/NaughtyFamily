using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NaughtyFamily.DBconn
{
    public class Book
    {
        [Key]
        public int BId { get; set; }

        public int book_id { get; set; }   //预约者Id  外键于userinfo

        [ForeignKey("book_id")]
        public virtual PetType PetType { get; set; }
    }
}