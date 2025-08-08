namespace YL.Utils.Json
{
    /// <summary>
    ///  Json配置根据自己项目的情况自己扩展
    /// </summary>
    public class JsonConfig
    {
        public JsonType JsonType { get; set; }
        public NewtonsoftConfig Newtonsoft { get; set; }
    }

    /// <summary>
    /// Newtonsoft.Json
    /// </summary>
    public class NewtonsoftConfig
    {
        public string DateTimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
    }
}