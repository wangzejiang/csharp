using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// OrderProductInfo实体
    /// </summary>
    [Serializable]
    public class OrderProductInfo
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public OrderProductInfo(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public OrderProductInfo(Object OpImageID, int? OpID, DateTime? UpdateDate, DateTime? CreateDate, decimal? OpPrice, decimal? OpWeigth, decimal? OpCount, decimal? OpPriceX, string OpName, string OpNumber, string OpSuppliter, string OpRemark)
        {
            this.OpImageID = OpImageID;
            this.OpID = OpID;
            this.UpdateDate = UpdateDate;
            this.CreateDate = CreateDate;
            this.OpPrice = OpPrice;
            this.OpWeigth = OpWeigth;
            this.OpCount = OpCount;
            this.OpPriceX = OpPriceX;
            this.OpName = OpName;
            this.OpNumber = OpNumber;
            this.OpSuppliter = OpSuppliter;
            this.OpRemark = OpRemark;
        }
        public byte[] OpImageBytes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Object OpImageID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? OpID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OpPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OpWeigth { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string OpName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OpNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OpSuppliter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OpRemark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OpPriceX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OpCount { get; set; }

        public decimal? priceCount { get; set; }    // 总成本
        public decimal? priceXCount { get; set; }   // 总售价
        public decimal? priceZCount { get; set; }   // 总利润
        public decimal? weigthCount { get; set; }   // 总重量
    }
}
