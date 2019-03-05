using System;

namespace YL.Utils.Extensions
{
    public static class DateTimeExt
    {
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DateTimeFormat1 = "yyyy-MM-dd HH:mm";
        public const string DateTimeFormat2 = "yyyy/MM/dd HH:mm:ss";
        public const string DateTimeFormatString = "yyyyMMddHHmmss";
        public const string DateTimeShortFormat = "yyyy-MM-dd";
        public const string DateTimeShortFormat2 = "yyyy/MM/dd";
        public const string SnokId = "yyyyMMddHHmmssffff";
        public static DateTime DateTime => DateTime.Now;

        public static DateTime ToDateTime(this string str)
        {
            return DateTime.TryParse(str, out DateTime date) == true ? date : DateTime.MinValue;
        }

        public static DateTime ToDateTimeB(this string str)
        {
            return DateTime.TryParse(str + " 00:00:00.000", out DateTime date) == true ? date : DateTime.MinValue;
        }

        public static DateTime ToDateTimeE(this string str)
        {
            return DateTime.TryParse(str + " 23:59:59.997", out DateTime date) == true ? date : DateTime.MinValue;
        }

        public static string ToDateTimeString(this DateTime dateTime, string format = DateTimeFormat)
        {
            return dateTime.ToString(format);
        }

        public static DateTime GetDateTime(string format = DateTimeFormat)
        {
            return DateTime.ToString(format).ToDateTime();
        }

        public static string GetDateTimeS(string format = DateTimeFormat)
        {
            return DateTime.ToString(format);
        }

        public static long GetTotalMilliseconds()
        {
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0);
            long timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
            return timeStamp;
        }

        public static DateTime TToDateTime(string timeStamp)
        {
            DateTime dtStart = new DateTime(1970, 1, 1, 0, 0, 0);
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}