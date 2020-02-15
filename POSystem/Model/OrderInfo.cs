using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// OrderInfo实体
    /// </summary>
    [Serializable]
    public class OrderInfo
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public OrderInfo(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public OrderInfo(int? OID, int? CID, int? UID, int? OStatus, DateTime? ODate, DateTime? CreateDate, DateTime? UpdateDate, decimal? OPrice, decimal? OWeigth, decimal? OFirstCost, string ONumber, string ORemark, string ORemark2)
        {
            this.OID = OID;
            this.CID = CID;
            this.UID = UID;
            this.OStatus = OStatus;
            this.ODate = ODate;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.OPrice = OPrice;
            this.OWeigth = OWeigth;
            this.OFirstCost = OFirstCost;
            this.ONumber = ONumber;
            this.ORemark = ORemark;
            this.ORemark2 = ORemark2;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? OID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? CID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? OStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ODate { get; set; }

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
        public decimal? OPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OWeigth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OFirstCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ONumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ORemark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ORemark2 { get; set; }
    }
}
