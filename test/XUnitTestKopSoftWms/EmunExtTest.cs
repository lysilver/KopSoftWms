using Xunit;
using YL.Utils.Extensions;
using YL.Utils.Pub;

namespace XUnitTestKopSoftWms
{
    public class EmunExtTest
    {
        [Fact]
        public void TestEnum()
        {
            var list = EnumExt.ToKVList<PubDictType>();
            var d = EnumExt.GetDescription<PubDictType>("unit");
            Assert.Equal(6, list.Count);
        }

        [Fact]
        public void TestGetDescriptionByValue()
        {
            var unit = EnumExt.GetDescription<PubDictType>("unit");
            Assert.Equal("单位类别", unit);
        }
    }
}