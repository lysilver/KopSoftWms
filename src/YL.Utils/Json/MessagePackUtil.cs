using MessagePack;

namespace YL.Utils.Json
{
    /// <summary>
    /// https://github.com/neuecc/MessagePack-CSharp
    /// </summary>
    public static class MessagePackUtil
    {
        public static string MpToJson(this object obj)
        {
            return MessagePackSerializer.ConvertToJson(MessagePackSerializer.Serialize(obj));
        }

        public static string MpToJson2<T>(this T t)
        {
            return MessagePackSerializer.SerializeToJson(t);
        }

        public static T MpToObj<T>(this string obj)
        {
            return MessagePackSerializer.Deserialize<T>(MessagePackSerializer.ConvertFromJson(obj));
        }
    }
}