using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace YL.Utils.Extensions

{
    /// <summary>
    /// String扩展
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 是null还是string.Empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// null、空还是仅由空白字符串组成
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsEmptyZero(this string str)
        {
            return string.IsNullOrWhiteSpace(str) || str == "0";
        }

        public static bool IsNull2(this string value)
        {
            return value == null || value == "" || value == string.Empty || value == " " || value.Length == 0;
        }

        public static bool IsEmpty(this object str)
        {
            if (str == null)
            {
                return true;
            }
            return string.IsNullOrWhiteSpace(str.ToString());
        }

        /// <summary>
        /// 判断是不是为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNullT<T>(this T t) where T : class
        {
            return t == null;
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source is null || source.Count <= 0;
        }

        /// <summary>
        /// 判断List<T>是不是为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNullT<T>(this List<T> t) where T : class
        {
            return t == null || t.Count == 0;
        }

        public static bool IsNullLt<T>(this List<T> t)
        {
            return t == null || t.Count == 0;
        }

        public static bool IsNullDt(this DataTable dt)
        {
            return dt == null || dt.Rows.Count == 0;
        }

        public static bool IsNullT<T>(this IEnumerable<T> value)
        {
            if (value == null)
                return true;
            return !value.Any();
        }

        public static bool IsNull<T>(this T t) where T : class
        {
            if (t == null)
            {
                return true;
            }
            if (t is string)
            {
                return string.IsNullOrWhiteSpace(t.ToString().Trim());
            }
            if (t is DBNull)
            {
                return true;
            }
            if (t.GetType() == typeof(DataTable))
            {
                Type entityType = typeof(T);
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
                DataTable dt = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                {
                    dt.Columns.Add(prop.Name);
                }
                return dt == null || dt.Rows.Count == 0;
            }
            return false;
        }

        public static string[] ToSplit(this object obj, char c = '|')
        {
            return obj.ToString().Split(c);
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToFirstUpper(this string str)
        {
            if (str.IsEmpty())
            {
                throw new ArgumentNullException(nameof(str));
            }
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// 字符串的长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="flag">默认字符集是UTF8,</param>
        /// <returns></returns>
        public static int LengthH(this string str, EncodingType type = EncodingType.UTF8)
        {
            return str.ToBytes(type).Length;
        }

        /// <summary>
        ///是否包含或全部是中文
        /// </summary>
        /// <param name="str"></param>
        /// <param name="match">true全中文，false含有中文</param>
        /// <returns></returns>
        public static bool IsChinese(this string str, bool match = false)
        {
            var bytes = str.ToBytes(EncodingType.gb2312);
            return match ? bytes.Length == str.Length * 2 : bytes.Length > str.Length;
        }

        public static bool IsMatch(this string value, string pattern, RegexOptions options)
        {
            return value != null && Regex.IsMatch(value, pattern, options);
        }

        public static bool IsMatch(this string value, string pattern)
        {
            return value != null && Regex.IsMatch(value, pattern);
        }
    }
}