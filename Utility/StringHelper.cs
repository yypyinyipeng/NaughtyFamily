using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace NaughtyFamily.Utility
{
    public class StringHelper
    {
        #region 清除字符串里面的html
        /// <summary>
        /// 清除字符串里面的html
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string CleanHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = Regex.Replace(Htmlstring, @"<script.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<style.*?</style>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<.*?>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = System.Web.HttpUtility.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        /// <summary>
        /// 随机生成字符串
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string RandomString(int Length)
        {
            var rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                int ch = rand.Next(26 + 26 + 10);
                if (ch < 26) sb.Append((char)(ch + 'A'));
                else if (ch < 26 + 26) sb.Append((char)(ch - 26 + 'a'));
                else sb.Append((char)(ch - 26 - 26 + '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string TimeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(TimeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(int TimeStamp)
        {
            return ToDateTime(TimeStamp.ToString());
        }

        /// <summary>
        /// DateTime转时间戳
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static int ToTimeStamp(System.DateTime Time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(Time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 随机生成随机数
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public static int RandomInt(int Begin, int End)
        {
            Random rand = new Random();
            var ret = rand.Next(End - Begin + 1);
            return ret + Begin;
        }
        /// <summary>
        /// 获取字符串的长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringLen(string str)
        {
            byte[] sarr = Encoding.Default.GetBytes(str);
            return sarr.Length;
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <param name="endStr"></param>
        /// <returns></returns>
        public static string SubString(string s, int l, string endStr)
        {
            string temp = s.Substring(0, (s.Length < 1 + l) ? s.Length : 1 + l);
            byte[] encodedBytes = ASCIIEncoding.ASCII.GetBytes(temp);

            string outputStr = "";
            int count = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if ((int)encodedBytes[i] == 63)
                    count += 2;
                else
                    count += 1;

                if (count <= l - endStr.Length)
                    outputStr += temp.Substring(i, 1);
                else if (count > l)
                    break;
            }
            if (count <= l)
            {
                outputStr = temp;
                endStr = "";
            }

            outputStr += endStr;

            return outputStr;
        }
    }
}