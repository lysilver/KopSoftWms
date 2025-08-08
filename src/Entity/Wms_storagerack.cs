using SqlSugar;
using System;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable(tableName: "wms_storagerack")]
    public partial class Wms_storagerack
    {
        public Wms_storagerack()
        {
            this.IsDel = 1;
            this.CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:货架Id
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long StorageRackId { get; set; }

        /// <summary>
        /// Desc:货架编号
        /// Default:
        /// Nullable:False
        /// </summary>
        public string StorageRackNo { get; set; }

        /// <summary>
        /// Desc:货架名称
        /// Default:
        /// Nullable:True
        /// </summary>
        public string StorageRackName { get; set; }

        /// <summary>
        /// Desc:所属仓库
        /// Default:
        /// Nullable:False
        /// </summary>
        public long? WarehouseId { get; set; }

        /// <summary>
        /// Desc:所属库区
        /// Default:
        /// Nullable:False
        /// </summary>
        public long? ReservoirAreaId { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Desc:1 0
        /// Default:1
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