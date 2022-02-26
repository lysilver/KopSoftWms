using System;
using System.Collections.Generic;
using YL.Core.Entity;

namespace YL.Core.Dto
{
    public class Wms_invmovedetailDto : Wms_invmovedetail
    {
        public long? SourceStoragerackId { get; set; }
        public string SourceStoragerack { get; set; }
        public long? AimStoragerackId { get; set; }
        public string AimStoragerack { get; set; }
        public string Pid { get; set; } //InventorymoveId

        public List<Wmsinvmovedetail> Detail { get; set; }
    }

    public partial class Wmsinvmovedetail
    {
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>
        public string MoveDetailId { get; set; }

        /// <summary>
        /// Desc:库存移动Id
        /// Default:
        /// Nullable:True
        /// </summary>
        public string InventorymoveId { get; set; }

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
        public string MaterialId { get; set; }

        /// <summary>
        /// Desc:计划数量
        /// Default:
        /// Nullable:True
        /// </summary>
        public decimal? PlanQty { get; set; }

        public decimal? Qty { get; set; }

        public string MaterialNo { get; set; }

        public string MaterialName { get; set; }

        /// <summary>
        /// Desc:实际数量
        /// Default:
        /// Nullable:True
        /// </summary>
        public decimal? ActQty { get; set; }

        /// <summary>
        /// Desc:审核人
        /// Default:
        /// Nullable:True
        /// </summary>
        public string AuditinId { get; set; }

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
        public string CreateBy { get; set; }

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
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Desc:修改时间
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}