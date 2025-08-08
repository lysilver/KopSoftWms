using System;
using YL.Utils.Check;
using YL.Utils.Env;
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
            return config.JsonType switch
            {
                JsonType.MessagePack => obj.MpToJson(),
                JsonType.ProtobufNet => throw new Exception("未实现"),
                JsonType.ServiceStackText => throw new Exception("未实现"),
                JsonType.Newtonsoft => obj.ToJson(config.Newtonsoft.DateTimeFormat),
                JsonType.TextJson => obj.ToTextJson(),
                _ => obj.ToTextJson(),
            };
        }

        public static T ToObjL<T>(this string obj)
        {
            var config = GlobalCore.GetRequiredService<JsonConfig>();
            return config.JsonType switch
            {
                JsonType.MessagePack => obj.MpToObj<T>(),
                JsonType.ProtobufNet => throw new Exception("未实现"),
                JsonType.ServiceStackText => throw new Exception("未实现"),
                JsonType.Newtonsoft => obj.ToObject<T>(),
                JsonType.TextJson => obj.ToTextObj<T>(),
                _ => obj.ToTextObj<T>(),
            };
        }
    }
}