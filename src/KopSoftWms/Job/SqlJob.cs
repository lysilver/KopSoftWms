using SqlSugar;
using System;
using YL.NetCore.DI;
using YL.Utils.Log;

namespace KopSoftWms
{
    /// <summary>
    /// 废弃过时TimeJob 后面使用YL.Scheduler替换
    /// </summary>
    public class SqlJob
    {
        private readonly SqlSugarClient _client;

        public SqlJob(SqlSugarClient client)
        {
            _client = client;
        }

        public void Run()
        {
            var _nlog = ServiceResolve.Resolve<ILogUtil>();
            GC.Collect();
        }
    }
}