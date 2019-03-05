using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Sys_serialnum
    {
        public Sys_serialnum()
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
        public int SerialNumberId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        public string SerialNumber { get; set; }

        public int SerialCount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Desc:前缀
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Desc:位数
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? Digit { get; set; }

        /// <summary>
        /// Desc:尾数
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? Mantissa { get; set; }

        /// <summary>
        /// Desc:1未删除   0删除
        /// Default:
        /// Nullable:False
        /// </summary>
        public byte IsDel { get; set; }

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
        /// Nullable:False
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