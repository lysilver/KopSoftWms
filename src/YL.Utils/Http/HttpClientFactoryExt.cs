using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YL.Utils.Extensions;

namespace YL.Utils.Http
{
    public static class HttpClientFactoryExt
    {
        public static string HttpPost(this IHttpClientFactory clientFactory, string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            var client = clientFactory.CreateClient();
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            using (HttpContent httpContent = new StringContent(HttpClientUtil.BuildParam(postData), Encoding.UTF8))
            {
                HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public static string HttpPost(this IHttpClientFactory clientFactory, string url, List<KeyValuePair<string, string>> postData = null, Dictionary<string, string> headers = null)
        {
            var client = clientFactory.CreateClient();
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            var content = new FormUrlEncodedContent(postData);
            var result = client.PostAsync(url, content);
            if (result.Result.IsSuccessStatusCode)
            {
                return result.Result.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return null;
            }
        }

        public static async Task<string> HttpPostAsync(this IHttpClientFactory clientFactory, string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            var client = clientFactory.CreateClient();
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            using (HttpContent httpContent = new StringContent(HttpClientUtil.BuildParam(postData), Encoding.UTF8))
            {
                HttpResponseMessage response = await client.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static string HttpGet(this IHttpClientFactory clientFactory, string url, Dictionary<string, string> postData = null, Dictionary<string, string> headers = null)
        {
            var client = clientFactory.CreateClient();
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            if (postData != null)
            {
                url = url + "?" + HttpClientUtil.BuildParam(postData);
            }
            var result = client.GetStringAsync(url).Result;
            return result;
        }
    }
}