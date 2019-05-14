using System;

namespace YL.Utils.Table
{
    public class JqGridModel
    {
        public class JqGrid
        {
            /// <summary>
            /// 每页显示行数
            /// </summary>
            public int rows { get; set; }

            /// <summary>
            /// 当前页
            /// </summary>
            public int page { get; set; }

            public int records { get; set; }
            public int total { get; }

            /// <summary>
            /// 排序方式
            /// </summary>
            public string sord { get; set; }

            /// <summary>
            /// 查询
            /// </summary>
            public string _search { get; set; }

            /// <summary>
            /// 排序字段
            /// </summary>
            public string sidx { get; set; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pageSize">当前页</param>
        /// <param name="pageIndex">每页显示</param>
        /// <param name="total">查询数量</param>
        /// <param name="data">数据list</param>
        /// <returns></returns>
        public static object GridData(int pageSize, int pageIndex, int total, object data)
        {
            if (pageSize == 0)
            {
                pageSize = 1;
            }
            var totalPages = (int)Math.Ceiling((float)total / pageSize);
            var jsonData = new
            {
                total = totalPages,
                page = pageIndex,
                records = total,
                rows = data
            };
            return jsonData;
        }

        public static object GridData(int total, JqGrid jq, object data)
        {
            var totalPages = (int)Math.Ceiling((float)total / jq.rows);
            var jsonData = new
            {
                total = totalPages,
                page = jq.page,
                records = total,
                rows = data
            };
            //var totalPages = (int)Math.Ceiling((float)count / jq.rows);
            //{
            //    total = totalPages,
            //    page = jq.page,
            //    records = count,
            //    rows = list.Select(
            //        s => new
            //        {
            //            SystemUserId = s.SystemUserId,
            //            CreateTime = s.CreateTime,
            //            Age = s.Age,
            //            Telephone = s.Telephone,
            //            IsAvtive = s.IsActive == 1 ? "是" : "否"
            //        }).ToArray()
            //};
            return jsonData;
        }
    }
}