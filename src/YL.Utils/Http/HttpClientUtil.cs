using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using YL.Utils.Check;
using YL.Utils.Extensions;
using YL.Utils.Security;
using YL.Utils.Json;

namespace YL.Utils.Http
{
    public class HttpClientUtil
    {
        public static string HttpPost(string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            CheckNull.ArgumentIsNullException(url, nameof(url));
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };
            using (var http = new HttpClient(handler))
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        http.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                using (HttpContent httpContent = new StringContent(BuildParam(postData), Encoding.UTF8))
                {
                    HttpResponseMessage response = http.PostAsync(url, httpContent).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        public static T HttpPost<T>(string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            CheckNull.ArgumentIsNullException(url, nameof(url));
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };
            using (var http = new HttpClient(handler))
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        http.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                using (HttpContent httpContent = new StringContent(BuildParam(postData), Encoding.UTF8))
                {
                    HttpResponseMessage response = http.PostAsync(url, httpContent).Result;
                    return response.Content.ReadAsStringAsync().Result.ToObjL<T>();
                }
            }
        }

        public static string HttpGet(string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            CheckNull.ArgumentIsNullException(url, nameof(url));
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };
            using (var http = new HttpClient(handler))
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        http.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                if (postData != null)
                {
                    url = url + "?" + BuildParam(postData);
                }
                HttpResponseMessage response = http.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public static T HttpGet<T>(string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            CheckNull.ArgumentIsNullException(url, nameof(url));
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };
            using (var http = new HttpClient(handler))
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        http.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                if (postData != null)
                {
                    url = url + "?" + BuildParam(postData);
                }
                HttpResponseMessage response = http.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result.ToObjL<T>();
            }
        }

        public static string BuildParam(List<KeyValuePair<string, string>> paramArray, Encoding encode = null)
        {
            string url = "";

            if (encode == null) encode = Encoding.UTF8;

            if (paramArray != null && paramArray.Count > 0)
            {
                var parms = "";
                foreach (var item in paramArray)
                {
                    parms += string.Format("{0}={1}&", EncoderUtil.UrlHttpUtilityEncoder(item.Key, encode), EncoderUtil.UrlHttpUtilityEncoder(item.Value, encode));
                }
                if (parms != "")
                {
                    parms = parms.TrimEnd('&');
                }
                url += parms;
            }
            return url;
        }

        public static string BuildParam(Dictionary<string, string> paramArray, Encoding encode = null)
        {
            string url = "";

            if (encode == null) encode = Encoding.UTF8;

            if (paramArray != null && paramArray.Count > 0)
            {
                var parms = "";
                foreach (var item in paramArray)
                {
                    parms += string.Format("{0}={1}&", EncoderUtil.UrlHttpUtilityEncoder(item.Key, encode), EncoderUtil.UrlHttpUtilityEncoder(item.Value, encode));
                }
                if (parms != "")
                {
                    parms = parms.TrimEnd('&');
                }
                url += parms;
            }
            return url;
        }
    }
}