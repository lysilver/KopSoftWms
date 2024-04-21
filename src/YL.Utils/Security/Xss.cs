using Ganss.Xss;

namespace YL.Utils.Security
{
    public class Xss
    {
        private HtmlSanitizer htmlSanitizer;
        private static Xss _xss;

        public Xss()
        {
            htmlSanitizer = new HtmlSanitizer();
            //htmlSanitizer.AllowedTags.Add("div");//标签白名单
            htmlSanitizer.AllowedAttributes.Add("class");//标签属性白名单,默认没有class标签属性
            //htmlSanitizer.AllowedCssProperties.Add("font-family");//CSS属性白名单
        }

        public static Xss GetXss()
        {
            return _xss ??= new Xss();
        }

        /// <summary>
        /// XSS过滤
        /// </summary>
        /// <param name="html">html代码</param>
        /// <returns>过滤结果</returns>
        public string Filter(string html)
        {
            var str = htmlSanitizer.Sanitize(html);
            return str;
        }
    }
}