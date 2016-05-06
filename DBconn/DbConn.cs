using NaughtyFamily.DBconn;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NaughtyFamily.DBconn
{
    public class DbConn : DbContext
    {
        public DbConn()
            : base("name=MySQLconnStr")
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }   // 用户信息表

        public DbSet<BBS> BBS { get; set; }   // 论坛表

        public DbSet<Reply_BBS> Reply_BBS { get; set; }   //论坛回复表

        public DbSet<PetInfo> PetInfo { get; set; }   // 宠物信息
        
        public DbSet<PetType> PetType { get; set; }   //宠物类型

        public DbSet<Book> Book { get; set; }   //预定表
    }
}