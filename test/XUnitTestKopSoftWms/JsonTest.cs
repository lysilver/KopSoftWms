using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Core.Dto;
using AutoFixture.Xunit2;
using AutoFixture;

namespace XUnitTestKopSoftWms
{
    public class JsonTest
    {
        [Fact]
        public void JilToJson()
        {
            //var a = new PubResult
            //{
            //    Data = null,
            //    Flag = true,
            //    Msg = "123"
            //};
            Fixture fixture = new Fixture();
            var a = fixture.Create<PubResult>();
            Assert.NotNull(a.JilToJson());
        }

        [Theory, AutoData]
        public void JilToJson2(PubResult a)
        {
            Assert.NotNull(a.JilToJson());
        }

        [Fact]
        public void JilToJsonCamelCase()
        {
            var a = new ServerSentEventsDto
            {
                Data = DateTime.Now.ToString(),
                Event = "message",
                Id = Guid.NewGuid().ToString(),
                Retry = "1000",
            };
            var b = a.JilToJsonCamelCase();
            var c = b.JilToObject<ServerSentEventsDto>();
            Assert.NotNull(c);
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
            Assert.NotNull(a.JilToJson().JilToObject<PubResult>());
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
    }
}