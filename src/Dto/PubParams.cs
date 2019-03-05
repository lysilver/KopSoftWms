using static YL.Utils.Table.Bootstrap;

namespace YL.Core.Dto
{
    public class PubParams
    {
        /// <summary>
        /// 设备查询参数
        /// </summary>
        public class DeviceBootstrapParams : BootstrapParams
        {
            public string DeptId { get; set; }
            public string DeviceType { get; set; }
            public string PropertyType { get; set; }
        }

        /// <summary>
        /// 字典查询参数
        /// </summary>
        public class DictBootstrapParams : BootstrapParams
        {
            public string DictType { get; set; }
        }

        /// <summary>
        /// 入库单查询参数
        /// </summary>
        public class StockInBootstrapParams : BootstrapParams
        {
            public string StockInType { get; set; }
            public string StockInStatus { get; set; }
        }

        /// <summary>
        /// 库存查询参数
        /// </summary>
        public class InventoryBootstrapParams : BootstrapParams
        {
            public string StorageRackId { get; set; }
            public string MaterialId { get; set; }
        }

        /// <summary>
        /// 出库单查询参数
        /// </summary>
        public class StockOutBootstrapParams : BootstrapParams
        {
            public string StockOutType { get; set; }
            public string StockOutStatus { get; set; }
        }

        public class StatusBootstrapParams : BootstrapParams
        {
            public string Status { get; set; }
        }
    }
}