using IRepository;
using IServices;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using YL.Core.Entity;
using YL.Core.Orm.SqlSugar;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Pub;
using YL.Utils.Table;

namespace Services
{
    public class Sys_logServices : BaseServices<Sys_log>, ISys_logServices
    {
        private readonly SqlSugarClient _client;
        private readonly IConfiguration _configuration;

        public Sys_logServices(
            IConfiguration configuration,
            SqlSugarClient client, ISys_logRepository repository) : base(repository)
        {
            _configuration = configuration;
            _client = client;
        }

        public string PageList(Bootstrap.BootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            var query = _client.Queryable<Sys_log, Sys_user, Sys_user>
                ((s, c, u) => new object[] {
                   JoinType.Left,s.CreateBy==c.UserId,
                   JoinType.Left,s.ModifiedBy==u.UserId
                 })
                 .Select((s, c, u) => new
                 {
                     LogId = s.LogId.ToString(),
                     s.LogIp,
                     s.LogType,
                     s.Url,
                     s.Browser,
                     s.Description,
                     CName = c.UserNickname,
                     s.CreateDate,
                     UName = u.UserNickname,
                     s.ModifiedDate
                 }).MergeTable();
            if (!bootstrap.search.IsEmpty())
            {
                query.Where((s) => s.LogType.Contains(bootstrap.search));
            }
            if (!bootstrap.datemin.IsEmpty() && !bootstrap.datemax.IsEmpty())
            {
                query.Where(s => s.CreateDate > bootstrap.datemin.ToDateTimeB() && s.CreateDate <= bootstrap.datemax.ToDateTimeE());
            }
            if (bootstrap.order.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                query.OrderBy($"MergeTable.{bootstrap.sort} desc");
            }
            else
            {
                query.OrderBy($"MergeTable.{bootstrap.sort} asc");
            }
            var list = query.ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
            return Bootstrap.GridData(list, totalNumber).JilToJson();
        }

        public string EChart(Bootstrap.BootstrapParams bootstrap)
        {
            //sql 实现方式
            //            string sql = "";
            //            if (_configuration["SqlSugar:DbType"] == "SqlServer")
            //            {
            //                sql = $@"SELECT CONVERT
            //	( VARCHAR ( 10 ), CreateDate, 121 ) AS CreateDate,
            //	COUNT( * ) AS COUNT
            //FROM
            //	Sys_log
            //WHERE
            //	LogType = 'login'
            //	AND CreateDate BETWEEN '{bootstrap.datemin}'
            //	AND '{bootstrap.datemax}'
            //GROUP BY
            //	CONVERT ( VARCHAR ( 10 ), CreateDate, 121 )
            //HAVING
            //	COUNT( * ) >= 0";
            //            }
            //            else
            //            {
            //                sql = $@"SELECT
            //	DATE_FORMAT( CreateDate, '%Y-%d-%m' ) AS CreateDate,
            //	COUNT( * ) AS COUNT
            //FROM
            //	Sys_log
            //WHERE
            //	LogType = 'login'
            //	AND CreateDate BETWEEN '{bootstrap.datemin}'
            //	AND '{bootstrap.datemax}'
            //GROUP BY
            //	DATE_FORMAT( CreateDate, '%Y-%d-%m' )
            //HAVING
            //	COUNT( * ) >= 0";
            //            }
            //var list = _client.Ado.SqlQuery<Log>(sql);
            var list = _client.Queryable
                (
                   _client.Queryable<Sys_log>()
                   .Where(s => s.LogType == LogType.login.EnumToString())
                   .Where(s => s.CreateDate > bootstrap.datemin.ToDateTimeB() && s.CreateDate <= bootstrap.datemax.ToDateTimeE())
                   .GroupBy(s =>
                       SqlFuncL.ToDateFormat(s.CreateDate)
                         )
                   .Having(s => SqlFunc.AggregateCount(s.LogId) >= 0)
                   .Select(s => new Log()
                   {
                       CreateDate = SqlFuncL.ToDateFormat(s.CreateDate),
                       COUNT = SqlFunc.AggregateCount(s.LogId)
                   })
                )
                .ToList();
            return list.JilToJson();
        }

        public class Log
        {
            public string CreateDate { get; set; }

            public int COUNT { get; set; }
        }
    }
}