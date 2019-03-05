using System;
using YL.Utils.Extensions;

namespace YL.Core.Orm.SqlSugar
{
    public partial class SqlFuncL
    {
        /// <summary>
        /// 将时间格式化成yyyy-MM-dd形式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateFormat<T>(T value)
        {
            throw new NotSupportedException("Can only be used in expressions");
        }
    }
}