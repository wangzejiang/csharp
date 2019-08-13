using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// UserInfo实体
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public UserInfo(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public UserInfo(int? UID, DateTime? CreateDate, DateTime? UpdateDate, string UName, string UPassword)
        {
            this.UID = UID;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.UName = UName;
            this.UPassword = UPassword;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UPassword { get; set; }
    }
}
