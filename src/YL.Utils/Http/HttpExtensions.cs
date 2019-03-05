using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YL.Utils.Json;
using YL.Utils.Extensions;
using System.Linq;

namespace YL.Utils.Http
{
    public static class HttpExtensions
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public static Task WriteJson<T>(this HttpResponse response, T obj)
        {
            response.ContentType = "application/json";
            return response.WriteAsync(JsonConvert.SerializeObject(obj));
        }

        public static void WriteJson<T>(this HttpResponse response, T obj, string contentType = null)
        {
            response.ContentType = contentType ?? "application/json";
            using (var writer = new HttpResponseStreamWriter(response.Body, Encoding.UTF8))
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.CloseOutput = false;
                    jsonWriter.AutoCompleteOnClose = false;
                    Serializer.Serialize(jsonWriter, obj);
                }
            }
        }

        public static Task WriteJson(this HttpResponse response, string str)
        {
            response.ContentType = "application/json";
            return response.WriteAsync(str);
        }

        public static async Task<T> ReadFromJsonJil<T>(this HttpContext httpContext)
        {
            using (var streamReader = new StreamReader(httpContext.Request.Body))
            {
                var obj = streamReader.JilToObject<T>();
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(obj, new ValidationContext(obj), results))
                {
                    return obj;
                }
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteJson(results.JilToJson());
                return default;
            }
        }

        public static async Task<T> ReadFromJson<T>(this HttpContext httpContext)
        {
            using (var streamReader = new StreamReader(httpContext.Request.Body))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var obj = Serializer.Deserialize<T>(jsonTextReader);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(obj, new ValidationContext(obj), results))
                {
                    return obj;
                }
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteJson(results);
                return default;
            }
        }

        /// <summary>
        /// Item1 参数，Item2 url,Item3 method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static (string, string, string) ReadResultExecutingContext(this ResultExecutingContext context)
        {
            var req = context.HttpContext.Request;
            req.EnableRewind();
            var method = req.Method;
            var url = $"{req.Scheme}://{req.Host}{req.PathBase}{req.Path}{req.QueryString}";
            var urlParam = req.QueryString.ToUriComponent();
            if (!urlParam.IsNull2())
            {
                var qs = QueryHelpers.ParseQuery(req.QueryString.ToUriComponent());
                return (qs.ToJsonL(), url, method);
            }
            if (req.HasFormContentType)
            {
                var result = req.ReadFormAsync().Result;
                var pairs = new Dictionary<string, string>();
                foreach (var item in result.Keys)
                {
                    pairs.Add(item, result[item]);
                }
                return (pairs.ToJsonL(), url, method);
            }
            using (var ms = new MemoryStream())
            {
                req.Body.Position = 0;
                req.Body.CopyTo(ms);
                var b = ms.ToArray();
                return (b.ByteToString(), url, method);
            }
        }

        public static string ReadFromResultExecutingContext(this ResultExecutingContext context)
        {
            var req = context.HttpContext.Request;
            req.EnableRewind();
            var method = req.Method;
            var url = $"{req.Scheme}://{req.Host}{req.PathBase}{req.Path}{req.QueryString}";
            var urlParam = req.QueryString.ToUriComponent();
            if (!urlParam.IsNull2())
            {
                var qs = QueryHelpers.ParseQuery(req.QueryString.ToUriComponent());
                return qs.ToJsonL();
            }
            if (req.HasFormContentType)
            {
                var result = req.ReadFormAsync().Result;
                var pairs = new Dictionary<string, string>();
                foreach (var item in result.Keys)
                {
                    pairs.Add(item, result[item]);
                }
                return pairs.ToJsonL();
            }
            using (var ms = new MemoryStream())
            {
                req.Body.Position = 0;
                req.Body.CopyTo(ms);
                var b = ms.ToArray();
                //req.Body.Position = 0;
                //Stream stream = req.Body;
                //byte[] buffer = new byte[req.ContentLength.Value];
                //stream.Read(buffer, 0, buffer.Length);
                //string querystring = buffer.ByteToString();
                return b.ByteToString();
            }
        }

        /// <summary>
        /// 只能获取FromBody
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string ReadFromResultExecutedContext(this ResultExecutedContext context)
        {
            var req = context.HttpContext.Request;
            req.EnableRewind();
            using (var ms = new MemoryStream())
            {
                req.Body.Position = 0;
                req.Body.CopyTo(ms);
                var b = ms.ToArray();
                return b.ByteToString();
            }
        }
    }
}