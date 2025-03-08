using System;

namespace YL.Utils.Json
{
    /// <summary>
    /// 目前使用TextJson
    /// </summary>
    public enum JsonType
    {
        MessagePack = 1,//https://github.com/neuecc/MessagePack-CSharp

        ProtobufNet = 2,

        [Obsolete("不在更新")]
        SimdJsonSharp = 3, //net core 3.0实现 https://github.com/EgorBo/SimdJsonSharp

        SpanJson = 4, // 不支持.net Standard 2.0 https://github.com/Tornhoof/SpanJson

        [Obsolete("不在更新")]
        SwifterJson = 5,//https://github.com/Dogwei/Swifter.Json

        [Obsolete("不在更新")]
        Utf8Json = 6, //https://github.com/neuecc/Utf8Json

        [Obsolete("不在更新")]
        Jil = 7, //https://github.com/kevin-montrose/Jil

        ServiceStackText = 8, //https://github.com/ServiceStack/ServiceStack

        Newtonsoft = 9, //https://github.com/JamesNK/Newtonsoft.Json

        /// <summary>
        /// 元组 IncludeFields = true
        /// </summary>
        TextJson = 10
    }
}