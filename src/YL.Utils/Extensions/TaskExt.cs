using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace YL.Utils.Extensions
{
    public static class TaskExt
    {
        public static Task<List<T>> ToListAsync<T>(this List<T> list)
        {
            return Task.FromResult(list);
        }

        public static Task<T> ToAsync<T>(this T list)
        {
            return Task.FromResult(list);
        }

        public static Task<DataTable> ToDataTableAsync<T>(this DataTable dt)
        {
            return Task.FromResult(dt);
        }
    }
}