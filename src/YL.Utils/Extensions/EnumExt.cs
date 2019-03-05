using AspectCore.Extensions.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace YL.Utils.Extensions
{
    public static class EnumExt
    {
        public static string GetDescription(this Enum obj)
        {
            var fi = obj.GetType().GetField(obj.ToString());
            var arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return arrDesc[0]?.Description;
        }

        public static string GetDescription<T>(this Enum obj)
        {
            var refactor = typeof(T).GetField(obj.ToString()).GetReflector();
            var arrDesc = refactor.GetCustomAttributes(typeof(DescriptionAttribute));
            return ((DescriptionAttribute)arrDesc[0]).Description;
        }

        public static T ToEnum<T>(this string obj)
        {
            return (T)Enum.Parse(typeof(T), obj);
        }

        public static string GetDescription<T>(string obj)
        {
            var refactor = typeof(T).GetField(obj).GetReflector();
            var arrDesc = refactor.GetCustomAttributes(typeof(DescriptionAttribute));
            return ((DescriptionAttribute)arrDesc[0]).Description;
        }

        public static Dictionary<int, string> ToDict(this Enum obj)
        {
            var enumDict = new Dictionary<int, string>();
            foreach (int enumValue in Enum.GetValues(obj.GetType()))
            {
                enumDict.Add(enumValue, enumValue.ToString());
            }
            return enumDict;
        }

        public static List<string> ToList<T>()
        {
            //Type t = typeof(T);
            //var ty = t.GetFields(BindingFlags.Public | BindingFlags.Static)
            //.Where(p => t.IsAssignableFrom(p.FieldType))
            //.Select(pi => (T)pi.GetValue(null))
            //.ToList();
            return Enum.GetValues(typeof(T)).Cast<T>().Select(x => x.ToString()).ToList();
        }

        public static List<KeyValuePair<int, string>> ToKVList<T>()
        {
            var keys = new List<KeyValuePair<int, string>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                DescriptionAttribute da = objArr?[0] as DescriptionAttribute;
                keys.Add(new KeyValuePair<int, string>(Convert.ToInt32(e), da.Description));
            }
            return keys;
        }

        public static List<KeyValuePair<int, string>> ToKVListLinq<T>()
        {
            Type t = typeof(T);
            return t.GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(p => t.IsAssignableFrom(p.FieldType))
        .Select(a => new KeyValuePair<int, string>(Convert.ToInt32(a.GetValue(null)),
        (a.GetCustomAttributes(typeof(DescriptionAttribute), true)?[0] as DescriptionAttribute).Description)
        ).ToList();
        }
    }
}