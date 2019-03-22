using MediatR;
using SqlSugar;
using System;

namespace YL.Core.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Sys_log : INotification
    {
        public Sys_log()
        {
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long LogId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string LogIp { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string Browser { get; set; }

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
        public DateTime? CreateDate { get; set; } = DateTime.Now;

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