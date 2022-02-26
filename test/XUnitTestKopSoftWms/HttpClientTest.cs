using Xunit;
using YL.Utils.Http;

namespace XUnitTestKopSoftWms
{
    public class HttpClientTest
    {
        [Fact]
        public void TestMethod1()
        {
            var str = HttpClientUtil.HttpGet("http://www.baidu.com", null);
            Assert.NotNull(str);
        }
    }
}