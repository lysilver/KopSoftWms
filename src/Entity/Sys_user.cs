using SqlSugar;
using System;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable(tableName: "sys_user")]
    public partial class Sys_user
    {
        public Sys_user()
        {
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long UserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string UserNickname { get; set; }

        public long? RoleId { get; set; }

        public string HeadImg { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// Desc:1 启用 0 禁用
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? IsEabled { get; set; } = 1;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string LoginIp { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? LoginDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? LoginTime { get; set; }

        /// <summary>
        /// Desc:0男 1女
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? Sex { get; set; }

        /// <summary>
        /// Desc:1未删除   0删除
        /// Default:
        /// Nullable:True
        /// </summary>
        public byte? IsDel { get; set; } = 1;

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? CreateBy { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public long? ModifiedBy { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}