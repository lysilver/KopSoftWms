using System.Text.Json.Serialization;

namespace YL.Core.Dto
{
    /// <summary>
    /// h5 Server-Sent-Events
    /// event data id retry
    /// </summary>
    public class ServerSentEventsDto
    {
        /// <summary>
        /// 表示该行用来声明事件的类型。浏览器在收到数据时，会产生对应类型的事件
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        /// 表示该行包含的是数据。以 data 开头的行可以出现多次。所有这些行都是该事件的数据。
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        ///表示该行用来声明事件的标识符（即数据的编号），不常用
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 表示该行用来声明浏览器在连接断开之后进行再次连接之前的等待时间
        /// </summary>
        [JsonPropertyName("retry")]
        public string Retry { get; set; }
    }
}