using Bogus;
using System.Collections.Generic;
using Xunit;
using YL.Utils.Json;
using YL.Utils.Pub;

namespace XUnitTestKopSoftWms
{
    public class JsonTest
    {
        [Fact]
        public void JilToJson()
        {
            var a = new PubResult
            {
                Data = null,
                Flag = true,
                Msg = "123"
            };
            Assert.NotNull(a.JilToJson());
        }

        public static TheoryData<PubResult> GetPubResults()
        {
            return new TheoryData<PubResult>
            {
            };
        }

        [Fact]
        public void JilToJson2()
        {
            var a = new PubResult
            {
                Data = null,
                Flag = true,
                Msg = "123"
            };
            Assert.NotNull(a.ToTextJson());
        }

        [Fact]
        public void JilToObj()
        {
            var a = new PubResult
            {
                Data = null,
                Flag = true,
                Msg = "123"
            };
            Assert.NotNull(a.ToTextJson().ToTextObj<PubResult>());
        }

        [Fact]
        public void MpToJson()
        {
            var a = new PubResult
            {
                Data = null,
                Flag = true,
                Msg = "123"
            };
            Assert.NotNull(a.MpToJson());
        }

        [Fact]
        public void MpToObj()
        {
            var a = new PubResult
            {
                Data = null,
                Flag = true,
                Msg = "123"
            };
            Assert.NotNull(a.MpToJson().MpToObj<PubResult>());
        }

        /// <summary>
        /// Bogus 地址
        /// https://github.com/bchavez/Bogus
        /// </summary>
        [Fact]
        public void MpToObj2()
        {
            var testData = new Faker<PubResult>()
                .RuleFor(u => u.Data, (f, u) => f.Internet.Email())
                .RuleFor(u => u.Flag, false)
                .RuleFor(u => u.Msg, f => f.Lorem.Text());
            var a = testData.Generate();
            Assert.NotNull(a.MpToJson().MpToObj<PubResult>());
        }
    }
}