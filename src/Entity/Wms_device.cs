using System;
using SqlSugar;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Wms_device
    {
        public Wms_device()
        {
            this.CreateDate = DateTime.Now;
            this.IsDel = Convert.ToByte("1");
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long DeviceId { get; set; }

        /// <summary>
        /// Desc:机台号
        /// Default:
        /// Nullable:True
        /// </summary>
        public string PlatformNo { get; set; }

        /// <summary>
        /// Desc:机身编号
        /// Default:
        /// Nullable:True
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// Desc:部门Id
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? DeviceType { get; set; }

        public long? PropertyType { get; set; }

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

        /// <summary>
        /// Desc:1未删除   0删除
        /// Default:1
        /// Nullable:False
        /// </summary>
        public byte IsDel { get; set; }
    }
}