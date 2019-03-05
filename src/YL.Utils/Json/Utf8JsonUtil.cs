using System.Collections.Generic;
using Utf8Json;

namespace YL.Utils.Json
{
    public static class Utf8JsonUtil
    {
        public static string Utf8JsonToJson(this object obj)
        {
            return JsonSerializer.ToJsonString(obj);
        }

        public static T Utf8JsonToObj<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static List<T> Utf8JsonToList<T>(this string json)
        {
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}