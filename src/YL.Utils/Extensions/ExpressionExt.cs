using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace YL.Utils.Extensions
{
    public static class ExpressionExt
    {
        //Expression<Func<Sys_user, bool>> predicate = null;
        public static Expression<Func<T, bool>> Init<T>()
        {
            return express => true;
        }

        public static Expression<Func<T, T1, T2, bool>> Init<T, T1, T2>()
        {
            return (s, c, u) => true;
        }

        /// <summary>
        /// 依赖System.Linq.Dynamic.Core
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Expression<Func<T, object>> InitO<T>(string name)
        {
            var parameters = DynamicExpressionParser.ParseLambda<T, object>(new ParsingConfig(), false, name);
            return parameters;
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> oldExpression, Expression<Func<T, bool>> newExpression)
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.Or(oldExpression.Body, newExpression.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> oldExpression, Expression<Func<T, bool>> newExpression)
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(oldExpression.Body, newExpression.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}