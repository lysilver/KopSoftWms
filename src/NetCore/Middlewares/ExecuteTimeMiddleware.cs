using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using YL.Utils.Log;

namespace YL.NetCore.Middlewares
{
    public class ExecuteTimeMiddleware
    {
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        private readonly RequestDelegate _next;

        public ExecuteTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() =>
            {
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                return Task.CompletedTask;
            });
            return _next(context);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableRewind();
            request.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return text?.Trim().Replace("\r", "").Replace("\n", "");
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            if (response.HasStarted)
            {
                return string.Empty;
            }
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text?.Trim().Replace("\r", "").Replace("\n", "");
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    var body = context.Response.Body;
        //    Stopwatch sw = new Stopwatch();
        //    try
        //    {
        //        using (var ms = new MemoryStream())
        //        {
        //            sw.Start();
        //            await _next(context);
        //            sw.Stop();
        //            context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = sw.ElapsedMilliseconds.ToString();
        //            Console.WriteLine($"RequestUrl:{context.Request.Path}, ExecuteTime:{sw.ElapsedMilliseconds}");
        //            await ms.CopyToAsync(body);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var log = context.RequestServices.GetService(typeof(ILogUtil)) as ILogUtil;
        //        log.Debug(ex);
        //    }
        //    finally
        //    {
        //        context.Response.Body = body;
        //    }
        //}
    }
}