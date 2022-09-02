using IdGen;
using System;
using System.Linq;
using Yitter.IdGenerator;

namespace YL.Utils.Pub
{
    public class PubId
    {
        public static readonly DateTime DefaultEpoch = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly IdGenerator Generator = new IdGenerator(0);
        private static IdGenerator _snowflake;

        /// <summary>
        /// 只能初始化一次
        /// // WorkerIdBitLength 默认值6，支持的 WorkerId 最大值为2^6-1，若 WorkerId 超过64
        /// </summary>
        /// <param name="workerId"></param>
        public static void InitId(ushort workerId = 0)
        {
            var options = new Yitter.IdGenerator.IdGeneratorOptions(workerId);
            options.WorkerIdBitLength = 10;
            YitIdHelper.SetIdGenerator(options);
        }

        // options.WorkerIdBitLength = 10;
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
                return YitIdHelper.NextId();
                //var id = Generator.CreateId();
                //return id;
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