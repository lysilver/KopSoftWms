using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using YL.Utils.Configs;

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
            var config = ConfigUtil.GetConfiguration;
            if (string.IsNullOrWhiteSpace(config["urls"]))
            {
                return Host.CreateDefaultBuilder(args)
                           .ConfigureWebHostDefaults(webBuilder =>
                           {
                               webBuilder.UseStartup<Startup>();
                           });
            }
            else
            {
                return Host.CreateDefaultBuilder(args)
                           .ConfigureWebHostDefaults(webBuilder =>
                           {
                               webBuilder.UseConfiguration(ConfigUtil.GetConfiguration);
                               webBuilder.UseStartup<Startup>();
                           });
            }
        }
    }
}