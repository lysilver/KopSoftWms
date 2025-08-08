namespace YL.Utils.Json
{
    /// <summary>
    /// 目前使用TextJson
    /// </summary>
    public enum JsonType
    {
        MessagePack = 1,//https://github.com/neuecc/MessagePack-CSharp

        ProtobufNet = 2,

        ServiceStackText = 8, //https://github.com/ServiceStack/ServiceStack

        Newtonsoft = 9, //https://github.com/JamesNK/Newtonsoft.Json

        /// <summary>
        /// 元组 IncludeFields = true
        /// </summary>
        TextJson = 10
    }
}