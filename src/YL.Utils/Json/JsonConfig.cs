using Jil;
using Swifter.Json;

namespace YL.Utils.Json
{
    /// <summary>
    ///  Json配置根据自己项目的情况自己扩展
    /// </summary>
    public class JsonConfig
    {
        public JsonType JsonType { get; set; }
        public JilConfig Jil { get; set; }
        public NewtonsoftConfig Newtonsoft { get; set; }
        public SwifterJsonConfig SwifterJsonConfig { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class JilConfig
    {
        /// <summary>
        /// [JilDirective]
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// Jil时间格式 我是在前台转的
        /// </summary>
        public DateTimeFormat DateTimeFormat { get; set; }
    }

    /// <summary>
    /// Newtonsoft.Json
    /// </summary>
    public class NewtonsoftConfig
    {
        public string DateTimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss"
    }

    public class SwifterJsonConfig
    {
        public JsonFormatterOptions JsonFormatterOptions { get; set; }
        public string DateTimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss"
    }
}