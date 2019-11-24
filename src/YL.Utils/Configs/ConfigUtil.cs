using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace YL.Utils.Configs
{
    public class ConfigUtil
    {
        private static IConfiguration _config;

        public static IConfiguration GetConfiguration
        {
            get
            {
                if (_config != null) return _config;
                var configBuilder =
                    new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .Add(new JsonConfigurationSource()
                    {
                        Path = "appsettings.json",
                        ReloadOnChange = true,
                    });
                //var builder = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json");
                _config = configBuilder.Build();
                return _config;
            }
            set { _config = value; }
        }

        public static string GetConnectionString(string key)
        {
            return GetConfiguration?.GetConnectionString(key);
        }

        public static IConfigurationSection GetSection(string key)
        {
            return GetConfiguration?.GetSection(key);
        }

        public static T GetAppSettings<T>(string key, string configFileName = "appsettings.json", string basePath = "") where T : class, new()
        {
            //Microsoft.Extensions.Options.ConfigurationExtensions
            basePath = string.IsNullOrWhiteSpace(basePath)
               ? Directory.GetCurrentDirectory()
               : Path.Combine(Directory.GetCurrentDirectory(), basePath);
            var configuration = new ConfigurationBuilder().SetBasePath(basePath)
                .AddJsonFile(configFileName, false, true)
                .Build();
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }

        public static IConfigurationRoot GetJsonConfig(string configFileName = "appsettings.json", string basePath = "")
        {
            basePath = string.IsNullOrWhiteSpace(basePath)
                ? Directory.GetCurrentDirectory()
                : Path.Combine(Directory.GetCurrentDirectory(), basePath);

            var configuration = new ConfigurationBuilder().SetBasePath(basePath)
                .AddJsonFile(configFileName, false, true)
                .Build();

            return configuration;
        }

        public static IConfigurationRoot GetXmlConfig(string configFileName = "appsettings.xml", string basePath = "")
        {
            basePath = string.IsNullOrWhiteSpace(basePath)
                ? Directory.GetCurrentDirectory()
                : Path.Combine(Directory.GetCurrentDirectory(), basePath);

            var configuration = new ConfigurationBuilder().AddXmlFile(config =>
            {
                config.Path = configFileName;
                config.FileProvider = new PhysicalFileProvider(basePath);
                config.ReloadOnChange = true;
            });

            return configuration.Build();
        }

        public static IConfigurationRoot GetIniConfig(string configFileName = "appsettings.ini", string basePath = "")
        {
            basePath = string.IsNullOrWhiteSpace(basePath)
                ? Directory.GetCurrentDirectory()
                : Path.Combine(Directory.GetCurrentDirectory(), basePath);

            var configuration = new ConfigurationBuilder().AddIniFile(config =>
            {
                config.Path = configFileName;
                config.FileProvider = new PhysicalFileProvider(basePath);
                config.ReloadOnChange = true;
            });

            return configuration.Build();
        }
    }
}