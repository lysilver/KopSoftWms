using SqlSugar;
using System;

namespace YL.Core.Entity
{
    public partial class Wms_Carrier
    {
        public Wms_Carrier()
        {
            this.IsDel = Convert.ToByte("1");
            this.CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:承运商id
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long CarrierId { get; set; }

        /// <summary>
        /// Desc:承运商编号
        /// Default:
        /// Nullable:False
        /// </summary>
        public string CarrierNo { get; set; }

        /// <summary>
        /// Desc:承运商名称
        /// Default:
        /// Nullable:False
        /// </summary>
        public string CarrierName { get; set; }

        /// <summary>
        /// Desc:地址
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Desc:联系人
        /// Default:
        /// Nullable:False
        /// </summary>
        public string CarrierPerson { get; set; }

        /// <summary>
        /// Desc:级别
        /// Default:
        /// Nullable:False
        /// </summary>
        public string CarrierLevel { get; set; }

        /// <summary>
        /// Desc:邮件
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Desc:电话
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Tel { get; set; }

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