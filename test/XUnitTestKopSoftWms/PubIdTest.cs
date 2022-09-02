using Xunit;
using YL.Utils.Pub;

namespace XUnitTestKopSoftWms
{
    /// <summary>
    /// Yitter.IdGenerator 16λid
    /// IdGen 18
    /// </summary>
    public class PubIdTest
    {
        public PubIdTest()
        {
            PubId.InitId();
        }

        [Fact]
        public void TestSnowflakeId()
        {
            long id = PubId.SnowflakeId;
            Assert.Equal(16, id.ToString().Length);
        }

        [Fact]
        public void TestSnowflakeId2()
        {
            long id = PubId.SnowflakeId2;
            Assert.Equal(18, id.ToString().Length);
        }
    }
}