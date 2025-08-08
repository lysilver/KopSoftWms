using YL.Utils.Json;

namespace YL.Utils.Table
{
    public class Bootstrap
    {
        /// <summary>
        /// bootstrap-table search=&sort=CreateDate&order=desc&offset=0&limit=10&_=1537247998287
        /// </summary>
        public class BootstrapParams
        {
            /// <summary>
            /// 10*(2-1)
            /// 页码*页面显示行数=offset
            /// </summary>
            public int offset { get; set; }

            /// <summary>
            /// 页面显示行数
            /// </summary>
            public int limit { get; set; }

            /// <summary>
            /// 排序字段
            /// </summary>
            public string sort { get; set; }

            /// <summary>
            /// 排序方式
            /// </summary>
            public string order { get; set; }

            public string search { get; set; }
            public string _ { get; set; }
            public string datemin { get; set; }
            public string datemax { get; set; }
            public string keyword { get; set; }
        }

        public static object GridData(object data, int total)
        {
            var jsonData = new
            {
                total,
                rows = data
            };
            return jsonData;
        }
    }
}