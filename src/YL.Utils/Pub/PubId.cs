using IdGen;
using System;
using System.Linq;

namespace YL.Utils.Pub
{
    public class PubId
    {
        public static readonly DateTime DefaultEpoch = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly IdGenerator Generator = new IdGenerator(0);
        private static IdGenerator _snowflake;

        public static IdGenerator GetInstance()
        {
            if (_snowflake == null)
                _snowflake = new IdGenerator(0);
            return _snowflake;
        }

        public static long SnowflakeId
        {
            get
            {
                var id = Generator.CreateId();
                return id;
            }
        }

        public static long SnowflakeId2
        {
            get
            {
                var generator = GetInstance();
                var id = generator.CreateId();
                return id;
            }
        }

        public static long[] SnowflakeIdA(int take = 1)
        {
            var id = Generator.Take(take);
            return id.ToArray();
        }

        public static string GetUuid() => Guid.NewGuid().ToString().Replace("-", "");
    }
}