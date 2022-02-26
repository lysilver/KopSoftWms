using SqlSugar;
using System;

namespace YL.Core.Orm.SqlSugar
{
    public class SqlSugarDao
    {
        //public SqlSugarClient Db;
        private static ConnectionConfig _config;

        public SqlSugarDao(ConnectionConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        //public SqlSugarDao()
        //{
        //    Db = new SqlSugarClient(new ConnectionConfig()
        //    {
        //        ConnectionString = "xx",
        //        DbType = DbType.SqlServer,
        //        IsAutoCloseConnection = true
        //    });
        //}

        public static SqlSugarClient DB
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _config.ConnectionString,//必填, 数据库连接字符串
                DbType = _config.DbType,         //必填, 数据库类型
                IsAutoCloseConnection = _config.IsAutoCloseConnection,       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                InitKeyType = _config.InitKeyType,    //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
            })
            {
                MappingTables = listTable,      //别名表
                IgnoreColumns = ignoreList,     //别名列
                MappingColumns = listColumn,    //过滤列
                IgnoreInsertColumns = listIgnoreColumn
            };
        }

        //public SimpleClient<Student> StudentDb { get { return new SimpleClient<Student>(DB); } }
        public static SqlSugarClient GetInstance()
        {
            try
            {
                var conn = new ConnectionConfig()
                {
                    ConnectionString = _config.ConnectionString,
                    DbType = _config.DbType,
                    IsAutoCloseConnection = _config.IsAutoCloseConnection,       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                    InitKeyType = _config.InitKeyType,    //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
                };

                var db = new SqlSugarClient(conn)
                {
                    MappingTables = listTable,      //别名表
                    IgnoreColumns = ignoreList,     //别名列
                    MappingColumns = listColumn,    //过滤列
                    IgnoreInsertColumns = listIgnoreColumn
                };
                //开启日志
                db.Ado.IsEnableLogEvent = true;
                //SQL执行完事件
                db.Aop.OnLogExecuted = (sql, pars) =>
                {
                };
                //SQL执行前事件
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                };
                db.Aop.OnError = (exp) =>//执行SQL 错误事件
                {
                    string ss = exp.Message;
                };
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库出错，请检查您的连接字符串和网络。 ex:" + ex.Message);
            }
        }

        private static readonly IgnoreColumnList listIgnoreColumn = new IgnoreColumnList()
        {
           new IgnoreColumn(){EntityName = "",PropertyName =""}
        };

        /// <summary>
        /// 解决数据库表名与实体名称不一致的问题 别名表
        /// </summary>
        private static readonly MappingTableList listTable = new MappingTableList()
        {
           new MappingTable() { EntityName="SystemUser",DbTableName="SystemUser",DbShortTaleName=""}
        };

        /// <summary>
        ///解决数据库列名与实体属性名称不一致的问题 别名列
        /// </summary>
        private static readonly MappingColumnList listColumn = new MappingColumnList()
        {
           new MappingColumn() {PropertyName="实体类属性名称",DbColumnName="数据库表里面的列名",EntityName="实体类名称"}
        };

        /// <summary>
        ///过滤列
        /// </summary>
        private static readonly IgnoreColumnList ignoreList = new IgnoreColumnList()
        {
           new IgnoreColumn() { EntityName="ID",PropertyName="SystemUser"}
        };
    }
}