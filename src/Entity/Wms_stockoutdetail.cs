using System;
using System.Linq;
using System.Text;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Wms_stockoutdetail
    {
        public Wms_stockoutdetail()
        {
            IsDel = Convert.ToByte("1");
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>
        public long StockOutDetailId { get; set; }

        /// <summary>
        /// Desc:出库单
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? StockOutId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? Status { get; set; }

        /// <summary>
        /// Desc:物料
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? MaterialId { get; set; }

        /// <summary>
        /// Desc:计划数量
        /// Default:
        /// Nullable:True
        /// </summary>
        public decimal? PlanOutQty { get; set; }

        /// <summary>
        /// Desc:实际数量
        /// Default:
        /// Nullable:True
        /// </summary>
        public decimal? ActOutQty { get; set; }

        /// <summary>
        /// Desc:货架
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? StoragerackId { get; set; }

        /// <summary>
        /// Desc:审核人
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? AuditinId { get; set; }

        /// <summary>
        /// Desc:审核时间
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? AuditinTime { get; set; }

        /// <summary>
        /// Desc:1 0
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? IsDel { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Remark { get; set; }

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