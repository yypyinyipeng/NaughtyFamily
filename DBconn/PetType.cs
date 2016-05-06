using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NaughtyFamily.DBconn
{
    public class PetType
    {
        [Key]
        public int PTId { get; set; }

        public string type { get; set; }   //宠物物种类型

    }
}