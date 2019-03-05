using Xunit;
using YL.Utils.Pub;

namespace XUnitTestKopSoftWms
{
    public class PubIdTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(5, 5);
        }

        [Fact]
        public void Test2()
        {
            long id = PubId.SnowflakeId;
            Assert.Equal(18, id.ToString().Length);
        }

        [Fact]
        public void Test3()
        {
            long id = PubId.SnowflakeId2;
            Assert.Equal(18, id.ToString().Length);
        }
    }
}