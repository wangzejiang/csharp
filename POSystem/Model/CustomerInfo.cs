using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// CustomerInfo实体
    /// </summary>
    [Serializable]
    public class CustomerInfo
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public CustomerInfo(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public CustomerInfo(int? CID, DateTime? CreateDate, DateTime? UpdateDate, string CName, string CPhone, string CAddress)
        {
            this.CID = CID;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.CName = CName;
            this.CPhone = CPhone;
            this.CAddress = CAddress;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? CID { get; set; }

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
        public string CName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CAddress { get; set; }
    }
}
