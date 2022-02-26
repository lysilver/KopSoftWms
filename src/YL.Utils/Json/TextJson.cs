using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace YL.Utils.Json
{
    public static class TextJson
    {
        private static readonly Lazy<JsonSerializerOptions> _instance =
        new Lazy<JsonSerializerOptions>(() =>
        {
            var options = new JsonSerializerOptions
            {
                // 不区分大小写
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                //// 首字母小写
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                AllowTrailingCommas = true,
                // 取消unicode编码
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            return options;
        });

        public static JsonSerializerOptions Instance
        {
            get { return _instance.Value; }
        }

        public static string ToTextJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, Instance);
        }

        public static T ToTextObj<T>(this string str)
        {
            return JsonSerializer.Deserialize<T>(str, Instance);
        }
    }
}