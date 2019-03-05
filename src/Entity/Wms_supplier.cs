using System;
using SqlSugar;

namespace YL.Core.Entity
{
    public class Wms_supplier
    {
        public Wms_supplier()
        {
            this.IsDel = Convert.ToByte("1");
            this.CreateDate = DateTime.Now;
        }


        /// <summary>
        /// Desc:供应商id
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long SupplierId { get; set; }

        /// <summary>
        /// Desc:供应商编号
        /// Default:
        /// Nullable:False
        /// </summary>
        public string SupplierNo { get; set; }

        /// <summary>
        /// Desc:供应商名称
        /// Default:
        /// Nullable:False
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Desc:供应商地址
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Desc:供应商电话
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Desc:联系人
        /// Default:
        /// Nullable:False
        /// </summary>
        public string SupplierPerson { get; set; }

        /// <summary>
        /// Desc:级别
        /// Default:
        /// Nullable:False
        /// </summary>
        public string SupplierLevel { get; set; }

        /// <summary>
        /// Desc:邮件
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Desc:是否删除 1未删除  0删除
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
