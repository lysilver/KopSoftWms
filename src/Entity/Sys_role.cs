using SqlSugar;
using System;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable(tableName: "sys_role")]
    public partial class Sys_role
    {
        public Sys_role()
        {
            IsDel = 1;
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long RoleId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Desc:admin #
        /// Default:
        /// Nullable:True
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// Desc:1未删除   0删除
        /// Default:1
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