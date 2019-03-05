using IServices;
using KopSoftWms.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Linq;
using Xunit;
using YL;
using YL.NetCoreApp.Extensions;
using YL.Core.Orm.SqlSugar;
using Microsoft.AspNetCore.Builder;
using YL.NetCore.DI;
using IRepository;
using Repository;
using Services;
using YL.Utils.Configs;
using YL.Utils.Table;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace XUnitTestKopSoftWms
{
    public class LogControllerTest : BaseControllerTest
    {
        private readonly SqlSugarClient _client;
        private readonly ISys_logServices _LogServices;
        private LogController controller;

        public LogControllerTest()
        {
            _client = ServiceProvider.GetRequiredService<SqlSugarClient>();
            _LogServices = ServiceProvider.GetRequiredService<ISys_logServices>();
            controller = new LogController(_client, _LogServices);
        }

        private new IServiceProvider ServiceProvider => GetServices();

        [Fact]
        public void TestIndex()
        {
            var sd = serviceDescriptors.GetEnumerator();
            Assert.NotNull(controller.Index());
        }

        [Fact]
        public void TestList()
        {
            Assert.NotNull(controller.List(GetBootstrap));
        }

        [Fact]
        public void TestDelete()
        {
            long[] arr = { 12, 34 };
            Assert.NotNull(controller.Delete(arr));
        }
    }
}