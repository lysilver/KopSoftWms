using System;
using SqlSugar;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Wms_stockindetail
    {
        public Wms_stockindetail()
        {
            IsDel = Convert.ToByte("1");
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long StockInDetailId { get; set; }

        /// <summary>
        /// Desc:入库单号
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? StockInId { get; set; }

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
        public decimal? PlanInQty { get; set; }

        /// <summary>
        /// Desc:实际数量
        /// Default:
        /// Nullable:True
        /// </summary>
        public decimal? ActInQty { get; set; }

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
        /// Default:1
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