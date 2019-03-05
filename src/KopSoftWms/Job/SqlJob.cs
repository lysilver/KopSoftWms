using Pomelo.AspNetCore.TimedJob;
using YL.NetCore.DI;
using YL.Utils.Log;
using SqlSugar;
using System;

namespace KopSoftWms
{
    public class SqlJob : Job
    {
        private readonly SqlSugarClient _client;

        public SqlJob(SqlSugarClient client)
        {
            _client = client;
        }

        [Invoke(IsEnabled = false, Begin = "2018-12-19 10:30", Interval = 1000 * 3, SkipWhileExecuting = true)]
        public void Run()
        {
            var _nlog = ServiceResolve.Resolve<ILogUtil>();
            GC.Collect();
        }
    }
}