﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Text.RegularExpressions;
using YL.Utils.Log;

namespace YL.Core.Orm.SqlSugar
{
    public static class SqlSugarServiceCollectionExt
    {
        public static IServiceCollection AddSqlSugarDao(this IServiceCollection services, Action<ConnectionConfig> configAction, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var config = new ConnectionConfig();
            configAction.Invoke(config);
            switch (lifetime)
            {
                default:
                    services.AddScoped(serviceProvider =>
                    {
                        return new SqlSugarDao(config);
                    });
                    break;
            }

            return services;
        }

        public static IServiceCollection AddSqlSugarClient<T>(this IServiceCollection services, Action<ConnectionConfig> configAction, ServiceLifetime lifetime = ServiceLifetime.Scoped) where T : SqlSugarClient
        {
            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                case ServiceLifetime.Singleton:
                case ServiceLifetime.Scoped:

                    services.AddScoped(serviceProvider =>
                    {
                        var configS = new ConnectionConfig()
                        {
                            ConfigureExternalServices = new ConfigureExternalServices
                            {
                                SqlFuncServices = SqlSugarConfig.GetLambda()
                            }
                        };
                        configAction.Invoke(configS);
                        var db = new SqlSugarClient(configS)
                        {
                            MappingTables = SqlSugarConfig.listTable
                        };
                        var log = serviceProvider.GetRequiredService<ILogUtil>();
                        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                        string flag = configuration["Log:sqllog"];
                        if (string.IsNullOrWhiteSpace(flag))
                        {
                            flag = "false";
                        }
                        if (flag.Equals("true", StringComparison.OrdinalIgnoreCase))
                        {
                            db.Ado.IsEnableLogEvent = true;
                            //SQL执行前事件
                            db.Aop.OnLogExecuting = (sql, pars) =>
                            {
                                foreach (var item in pars)
                                {
                                    sql = ReplaceCount(sql, item.ParameterName, $"'{item.Value?.ToString()}'");
                                }
                                log.Info($"执行前SQL: {sql}");
                                //log.Info(db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                            };
                            //SQL执行完事件
                            db.Aop.OnLogExecuted = (sql, pars) =>
                            {
                                foreach (var item in pars)
                                {
                                    sql = ReplaceCount(sql, item.ParameterName, $"'{item.Value?.ToString()}'");
                                }
                                log.Info($"执行后SQL: {sql}");
                            };
                            db.Aop.OnError = (exp) =>//执行SQL 错误事件
                            {
                                log.Debug(exp, exp.Sql);
                            };
                        }
                        else
                        {
                            db.Ado.IsEnableLogEvent = false;
                        }

                        return (T)db;
                    });
                    break;
            }
            return services;
        }

        public static string ReplaceCount(string str, string reg, string newValue, int count = 1)
        {
            Regex r = new Regex(reg);
            str = r.Replace(str, newValue, count);
            return str;
        }
    }
}