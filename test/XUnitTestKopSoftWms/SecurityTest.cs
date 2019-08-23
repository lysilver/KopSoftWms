using AutoFixture.Xunit2;
using System;
using System.Linq;
using Xunit;
using YL.Utils.Security;

namespace XUnitTestKopSoftWms
{
    public class SecurityTest
    {
        [Fact]
        public void TestMethod1()
        {
            var str = "阿萨斯";
            var sd = str.ToSha1();
            Assert.Equal("55a10ac78972a76ee94d6be6bf00e2b2354b4f91", sd);
        }

        [Theory, AutoData]
        public void TestMethod2(string str)
        {
            var sd = str.ToMd52();
            var sd2 = str.ToMd5();
            Assert.Equal(sd, sd2);
        }
    }
}