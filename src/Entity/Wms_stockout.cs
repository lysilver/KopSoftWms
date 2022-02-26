using SqlSugar;
using System;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Wms_stockout
    {
        public Wms_stockout()
        {
            IsDel = Convert.ToByte("1");
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long StockOutId { get; set; }

        /// <summary>
        /// Desc:出库单，系统自动生成
        /// Default:
        /// Nullable:True
        /// </summary>
        public string StockOutNo { get; set; }

        /// <summary>
        /// Desc:出库订单
        /// Default:
        /// Nullable:True
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// Desc:出库类型
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? StockOutType { get; set; }

        /// <summary>
        /// Desc:客户
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? CustomerId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? StockOutStatus { get; set; }

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