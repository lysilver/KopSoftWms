using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using YL.Utils.Extensions;

namespace YL.Core.Orm.SqlSugar
{
    public static class SqlSugarConfig
    {
        public static List<SqlFuncExternal> GetLambda()
        {
            //Lambda自定义解析
            var expMethods = new List<SqlFuncExternal>
                        {
                            new SqlFuncExternal()
                            {
                                UniqueMethodName = "ToDateFormat",
                                MethodValue = (expInfo, dbType, expContext) =>
                                {
                                    switch (dbType)
                                    {
                                        case DbType.SqlServer:
                                            return $"CONVERT (VARCHAR (10), {expInfo.Args[0].MemberName}, 121 )";

                                        case DbType.MySql:
                                            return $"DATE_FORMAT( {expInfo.Args[0].MemberName}, '%Y-%d-%m' ) ";

                                        case DbType.Sqlite:
                                            return $"date({expInfo.Args[0].MemberName})";

                                        case DbType.PostgreSQL:
                                        case DbType.Oracle:
                                            return $"to_date({expInfo.Args[0].MemberName},yyyy-MM-dd)";

                                        default:
                                            throw new Exception("未实现");
                                    }
                                }
                            },
                        };
            return expMethods;
        }

        /// <summary>
        /// 默认是SqlServer
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <returns></returns>
        public static (DbType, string) GetConnectionString(IConfiguration configuration)
        {
            string type = configuration["SqlSugar:DbType"];
            var dbType = type.ToEnum<DbType>();
            switch (dbType)
            {
                case DbType.MySql:
                    return (DbType.MySql, configuration["SqlSugar:MySqlConnectionString"]);

                case DbType.SqlServer:
                    return (DbType.SqlServer, configuration["SqlSugar:SqlServerConnectionString"]);

                case DbType.Sqlite:
                    return (DbType.Sqlite, configuration["SqlSugar:SqliteConnectionString"]);

                case DbType.Oracle:
                    return (DbType.Oracle, configuration["SqlSugar:OracleConnectionString"]);

                case DbType.PostgreSQL:
                    return (DbType.PostgreSQL, configuration["SqlSugar:PostgreSQLConnectionString"]);

                default:
                    return (DbType.SqlServer, configuration["SqlSugar:SqlServerConnectionString"]);
            }
        }

        /// <summary>
        /// 解决数据库表名与实体名称不一致的问题 别名表
        /// </summary>
        public static readonly MappingTableList listTable = new MappingTableList()
        {
           new MappingTable() { EntityName="Sys_menu",DbTableName="sys_menu_wms",DbShortTaleName="menu"},
        };

        public static readonly MappingColumnList columns = new MappingColumnList()
        {
        };
    }
}