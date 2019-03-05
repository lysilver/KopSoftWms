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
            switch (count)
            {
                case 1:
                    return $"{obj:N1}";

                case 2:
                    return $"{obj:N2}";

                case 3:
                    return $"{obj:N3}";

                case 4:
                    return $"{obj:N4}";

                case 5:
                    return $"{obj:N5}";

                default:
                    return $"{obj:N2}";
            }
        }

        public static string ToFormat2(this object obj, int count = 3)
        {
            //string.Format("{0:F3}", obj)
            CheckNull.ArgumentIsNullException(obj, nameof(obj));
            switch (count)
            {
                case 1:
                    return $"{obj:F1}";

                case 2:
                    return $"{obj:F2}";

                case 3:
                    return $"{obj:F3}";

                case 4:
                    return $"{obj:F4}";

                case 5:
                    return $"{obj:F5}";

                default:
                    return $"{obj:F2}";
            }
        }
    }
}