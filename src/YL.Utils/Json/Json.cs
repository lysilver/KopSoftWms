using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using YL.Utils.Env;
using YL.Utils.Check;
using YL.Utils.Extensions;

namespace YL.Utils.Json
{
    public static class Json
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonL(this object obj)
        {
            var config = GlobalCore.GetRequiredService<JsonConfig>();
            CheckNull.ArgumentIsNullException(config, "请添加app.UseGlobalCore();services.AddJson();");
            switch (config.JsonType)
            {
                case JsonType.MessagePack:
                    return obj.MpToJson();

                case JsonType.ProtobufNet:
                    throw new Exception("未实现");

                case JsonType.SimdJsonSharp:
                    throw new Exception("未实现");

                case JsonType.SpanJson:
                    throw new Exception("未实现");

                case JsonType.SwifterJson:
                    if (config.SwifterJsonConfig.DateTimeFormat.IsEmpty())
                    {
                        return obj.SwifterToJson();
                    }
                    else
                    {
                        return obj.SwifterToJson(config.SwifterJsonConfig.DateTimeFormat, config.SwifterJsonConfig.JsonFormatterOptions);
                    }

                case JsonType.Utf8Json:
                    return obj.Utf8JsonToJson();

                case JsonType.Jil:
                    return obj.JilToJson();

                case JsonType.ServiceStackText:
                    throw new Exception("未实现");

                case JsonType.Newtonsoft:

                    return obj.ToJson(config.Newtonsoft.DateTimeFormat);

                default:
                    return obj.JilToJson();
            }
        }

        public static T ToObjL<T>(this string obj)
        {
            var config = GlobalCore.GetRequiredService<JsonConfig>();
            switch (config.JsonType)
            {
                case JsonType.MessagePack:
                    return obj.MpToObj<T>();

                case JsonType.ProtobufNet:
                    throw new Exception("未实现");

                case JsonType.SimdJsonSharp:
                    throw new Exception("未实现");

                case JsonType.SpanJson:
                    throw new Exception("未实现");

                case JsonType.SwifterJson:
                    return obj.SwifterToObj<T>();

                case JsonType.Utf8Json:
                    return obj.Utf8JsonToObj<T>();

                case JsonType.Jil:
                    return obj.JilToObject<T>();

                case JsonType.ServiceStackText:
                    throw new Exception("未实现");

                case JsonType.Newtonsoft:
                    return obj.ToObject<T>();

                default:
                    return obj.JilToObject<T>();
            }
        }
    }
}