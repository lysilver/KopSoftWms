using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;

namespace YL.Utils.Security
{
    public class EncoderUtil
    {
        //HtmlEncoder.Default.Encode
        //HttpUtility.HtmlEncode();
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EEncoder(string str)
        {
            return HtmlEncoder.Default.Encode(str);
        }

        public static string JsEncoder(string str)
        {
            return JavaScriptEncoder.Default.Encode(str);
        }

        public static string HtmlHttpUtilityEncoder(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        public static string HtmlHttpUtilityDecoder(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        public static string UrlHttpUtilityEncoder(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlHttpUtilityEncoder(string str, Encoding encode = null)
        {
            if (encode == null)
            {
                encode = Encoding.UTF8;
            }
            return HttpUtility.UrlEncode(str, Encoding.UTF8);
        }

        public static string UrlHttpUtilityDecoder(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlHttpUtilityDecoder(string str, Encoding encode = null)
        {
            if (encode == null)
            {
                encode = Encoding.UTF8;
            }
            return HttpUtility.UrlDecode(str, encode);
        }

        public static string UrlEncode(string str)
        {
            return UrlEncoder.Default.Encode(str);
        }

        public static string WebUrlEncode(string str)
        {
            return WebUtility.UrlEncode(str);
        }

        public static string WebUrlDecode(string str)
        {
            return WebUtility.UrlDecode(str);
        }

        public static string WebHtmlEncode(string str)
        {
            return WebUtility.HtmlEncode(str);
        }

        public static string WebHtmlDecode(string str)
        {
            return WebUtility.HtmlDecode(str);
        }
    }
}