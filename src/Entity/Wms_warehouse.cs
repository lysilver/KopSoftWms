using System;
using SqlSugar;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Wms_warehouse
    {
        public Wms_warehouse()
        {
            this.IsDel = Convert.ToByte("1");
            this.CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long WarehouseId { get; set; }

        /// <summary>
        /// Desc:仓库编号
        /// Default:
        /// Nullable:False
        /// </summary>
        public string WarehouseNo { get; set; }

        /// <summary>
        /// Desc:仓库名称
        /// Default:
        /// Nullable:False
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// Desc:是否删除 1未删除  0删除
        /// Default:1
        /// Nullable:True
        /// </summary>
        public byte? IsDel { get; set; }

        /// <summary>
        /// Desc:备注
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
        /// Default:DateTime.Now
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