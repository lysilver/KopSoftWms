using SqlSugar;
using System;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Wms_delivery
    {
        public Wms_delivery()
        {
            CreateDate = DateTime.Now;
            IsDel = Convert.ToByte("1");
        }

        /// <summary>
        /// Desc:发货主键
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long DeliveryId { get; set; }

        /// <summary>
        /// Desc:出库单主表Id
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? StockOutId { get; set; }

        /// <summary>
        /// Desc:承运商Id
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? CarrierId { get; set; }

        /// <summary>
        /// Desc:发货日期
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Desc:快递单号
        /// Default:
        /// Nullable:True
        /// </summary>
        public string TrackingNo { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Desc:1 0
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? IsDel { get; set; }

        /// <summary>
        /// Desc:创建人
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? CreateBy { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Desc:修改人
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? ModifiedBy { get; set; }

        /// <summary>
        /// Desc:修改时间
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}