using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using YL.Utils.Extensions;

namespace YL.Utils.Json
{
    /// <summary>
    ///https://github.com/JamesNK/Newtonsoft.Json
    /// </summary>
    public static class Newtonsoft
    {
        public static object ToJson(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject(json);
        }

        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        public static string ToJson(this object obj, string dateTimeFormat)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = dateTimeFormat.IsEmpty() ? DateTimeExt.DateTimeFormat : dateTimeFormat };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        public static T ToObject<T>(this string json)
        {
            return json == null ? default : JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T> ToList<T>(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static DataTable ToTable(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<DataTable>(json);
        }

        public static JObject ToJObject(this string json)
        {
            return json == null ? JObject.Parse("{}") : JObject.Parse(json.Replace("&nbsp;", ""));
        }
    }
}