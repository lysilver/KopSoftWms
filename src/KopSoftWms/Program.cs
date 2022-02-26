using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace YL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                           .ConfigureWebHostDefaults(webBuilder =>
                           {
                               webBuilder.UseStartup<Startup>();
                               webBuilder.CaptureStartupErrors(true);
                               webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                               webBuilder.UseShutdownTimeout(TimeSpan.FromSeconds(10));
                               webBuilder.ConfigureLogging(configureLogging =>
                               {
                                   configureLogging.ClearProviders();
                                   configureLogging.AddConsole();
                                   configureLogging.SetMinimumLevel(LogLevel.Debug);
                               }).UseNLog();
                           });
        }
    }
}