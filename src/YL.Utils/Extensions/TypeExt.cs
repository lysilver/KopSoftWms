using System;
using System.ComponentModel;
using System.Globalization;
using YL.Utils.Check;

namespace YL.Utils.Extensions
{
    /// <summary>
    /// 类型转换
    /// </summary>
    public static class TypeExt
    {
        public static int ToInt32(this object obj)
        {
            return int.TryParse(obj.ToString(), out int a) == true ? a : 0;
        }

        public static int ToInt32(this Enum obj)
        {
            return Convert.ToInt32(obj);
        }

        public static string EnumToString(this Enum obj)
        {
            return Convert.ToString(obj);
        }

        public static byte ToByte(this Enum obj)
        {
            return Convert.ToByte(obj);
        }

        public static byte ToByte(this object obj)
        {
            return byte.TryParse(obj.ToString(), out byte a) == true ? a : (byte)0;
        }

        public static long ToInt64(this object obj)
        {
            return long.TryParse(obj.ToString(), out long a) == true ? a : 0;
        }

        public static float ToFloat(this object obj)
        {
            return float.TryParse(obj.ToString(), out float a) == true ? a : 0;
        }

        public static decimal ToDecimal(this object obj)
        {
            return decimal.TryParse(obj.ToString(), out decimal a) == true ? a : 0;
        }

        public static double ToDouble(this object obj)
        {
            return double.TryParse(obj.ToString(), out double a) == true ? a : 0;
        }

        public static T To2<T>(this object obj)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
            }

            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        public static T To<T>(this object obj)
        {
            if (obj.IsEmpty())
            {
                //default(T)
                return default;
            }
            Type type = typeof(T);
            var typeName = type.Name.ToLower();
            try
            {
                if (obj is string)
                {
                    return (T)(object)obj.ToString();
                }
                return (T)obj;
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        ///12.345
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="count">精度</param>
        /// <returns></returns>
        public static string ToFormat(this object obj, int count = 3)
        {
            //string.Format("{0:N3}", obj)
            return count switch
            {
                1 => $"{obj:N1}",
                2 => $"{obj:N2}",
                3 => $"{obj:N3}",
                4 => $"{obj:N4}",
                5 => $"{obj:N5}",
                _ => $"{obj:N2}",
            };
        }

        public static string ToFormat2(this object obj, int count = 3)
        {
            //string.Format("{0:F3}", obj)
            CheckNull.ArgumentIsNullException(obj, nameof(obj));
            return count switch
            {
                1 => $"{obj:F1}",
                2 => $"{obj:F2}",
                3 => $"{obj:F3}",
                4 => $"{obj:F4}",
                5 => $"{obj:F5}",
                _ => $"{obj:F2}",
            };
        }
    }
}