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
        public OrderInfo(int? OID, int? CID, int? OStatus, DateTime? ODate, DateTime? CreateDate, DateTime? UpdateDate, decimal? OWeigth, decimal? OPrice, decimal? OPriceX, decimal? OPriceOK, decimal? OPriceZ, string UName, string ONumber, string CName, string CPhone, string CAddress, string ORemark, string ORemark2)
        {
            this.OID = OID;
            this.CID = CID;
            this.OStatus = OStatus;
            this.ODate = ODate;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.OWeigth = OWeigth;
            this.OPrice = OPrice;
            this.OPriceX = OPriceX;
            this.OPriceOK = OPriceOK;
            this.OPriceZ = OPriceZ;
            this.UName = UName;
            this.ONumber = ONumber;
            this.CName = CName;
            this.CPhone = CPhone;
            this.CAddress = CAddress;
            this.ORemark = ORemark;
            this.ORemark2 = ORemark2;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? OID { get; set; }
        public int? CID { get; set; }

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
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ONumber { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public decimal? OWeigth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OPriceX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OPriceZ { get; set; }
        public decimal? OPriceOK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UName { get; set; }
        
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
