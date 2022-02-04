using System;
using System.Collections.Generic;
using System.Text;

namespace YL.Core.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// Desc:1未删除   0 Delete
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