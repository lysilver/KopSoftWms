using IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq.Expressions;
using YL.Utils.Extensions;
using YL.Utils.Json;
using YL.Utils.Table;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public SqlSugarClient _db;

        public BaseRepository(SqlSugarClient dbContext)
        {
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region add

        public bool Insert(T t)
        {
            return _db.Insertable(t).ExecuteCommand() > 0;
        }

        public bool Insert(SqlSugarClient client, T t)
        {
            return client.Insertable(t).ExecuteCommand() > 0;
        }

        public long InsertBigIdentity(T t)
        {
            return _db.Insertable(t).ExecuteReturnBigIdentity();
        }

        public bool Insert(List<T> t)
        {
            return _db.Insertable(t).ExecuteCommand() > 0;
        }

        public DbResult<bool> InsertTran(T t)
        {
            var result = _db.Ado.UseTran(() =>
            {
                _db.Insertable(t).ExecuteCommand();
            });
            return result;
        }

        public DbResult<bool> InsertTran(List<T> t)
        {
            var result = _db.Ado.UseTran(() =>
            {
                _db.Insertable(t).ExecuteCommand();
            });
            return result;
        }

        public T InsertReturnEntity(T t)
        {
            return _db.Insertable(t).ExecuteReturnEntity();
        }

        public T InsertReturnEntity(T t, string sqlWith = SqlWith.UpdLock)
        {
            return _db.Insertable(t).With(sqlWith).ExecuteReturnEntity();
        }

        public bool ExecuteCommand(string sql, object parameters)
        {
            return _db.Ado.ExecuteCommand(sql, parameters) > 0;
        }

        public bool ExecuteCommand(string sql, params SugarParameter[] parameters)
        {
            return _db.Ado.ExecuteCommand(sql, parameters) > 0;
        }

        public bool ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _db.Ado.ExecuteCommand(sql, parameters) > 0;
        }

        #endregion add

        #region update

        public bool UpdateEntity(T entity)
        {
            return _db.Updateable(entity).ExecuteCommand() > 0;
        }

        public bool Update(T entity, Expression<Func<T, bool>> expression)
        {
            return _db.Updateable(entity).Where(expression).ExecuteCommand() > 0;
        }

        public bool Update(T entity, Expression<Func<T, object>> expression)
        {
            return _db.Updateable(entity).UpdateColumns(expression).ExecuteCommand() > 0;
        }

        public bool Update(T entity, Expression<Func<T, object>> expression, Expression<Func<T, bool>> where)
        {
            return _db.Updateable(entity).UpdateColumns(expression).Where(where).ExecuteCommand() > 0;
        }

        public bool Update(SqlSugarClient client, T entity, Expression<Func<T, object>> expression, Expression<Func<T, bool>> where)
        {
            return client.Updateable(entity).UpdateColumns(expression).Where(where).ExecuteCommand() > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <param name="isNull">默认为true</param>
        /// <returns></returns>
        public bool Update(T entity, List<string> list = null, bool isNull = true)
        {
            if (list.IsNullT())
            {
                list = new List<string>()
            {
                "CreateBy",
                "CreateDate"
            };
            }
            //_db.Updateable(entity).IgnoreColumns(c => list.Contains(c)).Where(isNull).ExecuteCommand()
            return _db.Updateable(entity).IgnoreColumns(isNull).IgnoreColumns(list.ToArray()).ExecuteCommand() > 0;
        }

        public bool Update(List<T> entity)
        {
            var result = _db.Ado.UseTran(() =>
            {
                _db.Updateable(entity).ExecuteCommand();
            });
            return result.IsSuccess;
        }

        #endregion update

        public DbResult<bool> UseTran(Action action)
        {
            var result = _db.Ado.UseTran(() => action());
            return result;
        }

        public DbResult<bool> UseTran(SqlSugarClient client, Action action)
        {
            var result = client.Ado.UseTran(() => action());
            return result;
        }

        public bool UseTran2(Action action)
        {
            var result = _db.Ado.UseTran(() => action());
            return result.IsSuccess;
        }

        #region delete

        public bool Delete(Expression<Func<T, bool>> expression)
        {
            return _db.Deleteable<T>().Where(expression).ExecuteCommand() > 0;
        }

        public bool Delete<PkType>(PkType[] primaryKeyValues)
        {
            return _db.Deleteable<T>().In(primaryKeyValues).ExecuteCommand() > 0;
        }

        public bool Delete(object obj)
        {
            return _db.Deleteable<T>().In(obj).ExecuteCommand() > 0;
        }

        #endregion delete

        #region query

        public bool IsAny(Expression<Func<T, bool>> expression)
        {
            //_db.Queryable<T>().Any();
            return _db.Queryable<T>().Where(expression).Any();
        }

        public ISugarQueryable<T> Queryable()
        {
            return _db.Queryable<T>();
        }

        public ISugarQueryable<ExpandoObject> Queryable(string tableName, string shortName)
        {
            return _db.Queryable(tableName, shortName);
        }

        public List<T> QueryableToList(Expression<Func<T, bool>> expression)
        {
            return _db.Queryable<T>().Where(expression).ToList();
        }

        public string QueryableToJson(string select, Expression<Func<T, bool>> expressionWhere)
        {
            var query = _db.Queryable<T>().Select(select).Where(expressionWhere).ToList();
            return query.JilToJson();
        }

        public T QueryableToEntity(Expression<Func<T, bool>> expression)
        {
            return _db.Queryable<T>().Where(expression).First();
        }

        public List<T> QueryableToList(string tableName)
        {
            return _db.Queryable<T>(tableName).ToList();
        }

        public List<T> QueryableToList(string tableName, Expression<Func<T, bool>> expression)
        {
            return _db.Queryable<T>(tableName).Where(expression).ToList();
        }

        public (List<T>, int) QueryableToPage(Expression<Func<T, bool>> expression, int pageIndex = 0, int pageSize = 10)
        {
            int totalNumber = 0;
            var list = _db.Queryable<T>().Where(expression).ToPageList(pageIndex, pageSize, ref totalNumber);
            return (list, totalNumber);
        }

        public (List<T>, int) QueryableToPage(Expression<Func<T, bool>> expression, string order, int pageIndex = 0, int pageSize = 10)
        {
            int totalNumber = 0;
            var list = _db.Queryable<T>().Where(expression).OrderBy(order).ToPageList(pageIndex, pageSize, ref totalNumber);
            return (list, totalNumber);
        }

        public (List<T>, int) QueryableToPage(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderFiled, string orderBy, int pageIndex = 0, int pageSize = 10)
        {
            int totalNumber = 0;

            if (orderBy.Equals("DESC", StringComparison.OrdinalIgnoreCase))
            {
                var list = _db.Queryable<T>().Where(expression).OrderBy(orderFiled, OrderByType.Desc).ToPageList(pageIndex, pageSize, ref totalNumber);
                return (list, totalNumber);
            }
            else
            {
                var list = _db.Queryable<T>().Where(expression).OrderBy(orderFiled, OrderByType.Asc).ToPageList(pageIndex, pageSize, ref totalNumber);
                return (list, totalNumber);
            }
        }

        public (List<T>, int) QueryableToPage(Expression<Func<T, bool>> expression, Bootstrap.BootstrapParams bootstrap)
        {
            int totalNumber = 0;
            if (bootstrap.offset != 0)
            {
                bootstrap.offset = bootstrap.offset / bootstrap.limit + 1;
            }
            if (bootstrap.order.Equals("DESC", StringComparison.OrdinalIgnoreCase))
            {
                var list = _db.Queryable<T>().Where(expression).OrderBy(bootstrap.sort).ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
                return (list, totalNumber);
            }
            else
            {
                var list = _db.Queryable<T>().Where(expression).OrderBy(bootstrap.sort).ToPageList(bootstrap.offset, bootstrap.limit, ref totalNumber);
                return (list, totalNumber);
            }
        }

        public List<T> SqlQueryToList(string sql, object obj = null)
        {
            return _db.Ado.SqlQuery<T>(sql, obj);
        }

        #endregion query

        /// <summary>
        /// 此方法不带output返回值
        /// var list = new List<SugarParameter>();
        /// list.Add(new SugarParameter(ParaName, ParaValue)); input
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable UseStoredProcedureToDataTable(string procedureName, List<SugarParameter> parameters)
        {
            return _db.Ado.UseStoredProcedure().GetDataTable(procedureName, parameters);
        }

        /// <summary>
        /// 带output返回值
        /// var list = new List<SugarParameter>();
        /// list.Add(new SugarParameter(ParaName, ParaValue, true));  output
        /// list.Add(new SugarParameter(ParaName, ParaValue)); input
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public (DataTable, List<SugarParameter>) UseStoredProcedureToTuple(string procedureName, List<SugarParameter> parameters)
        {
            var result = (_db.Ado.UseStoredProcedure().GetDataTable(procedureName, parameters), parameters);
            return result;
        }
    }
}