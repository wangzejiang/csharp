using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// ProductInfo实体
    /// </summary>
    [Serializable]
    public class ProductInfo
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public ProductInfo(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public ProductInfo(Object PImageID, int? PID, DateTime? UpdateDate, DateTime? CreateDate, decimal? PPrice, decimal? PPriceX, decimal? PWeigth, string PName, string PNumber, string PSuppliter, string PRemark)
        {
            this.PImageID = PImageID;
            this.PID = PID;
            this.UpdateDate = UpdateDate;
            this.CreateDate = CreateDate;
            this.PPrice = PPrice;
            this.PPriceX = PPriceX;
            this.PWeigth = PWeigth;
            this.PName = PName;
            this.PNumber = PNumber;
            this.PSuppliter = PSuppliter;
            this.PRemark = PRemark;
        }
        public byte[] PImageBytes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Object PImageID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? PID { get; set; }

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
        public string PName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PSuppliter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PPrice { get; set; }

        public decimal? PPriceX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PWeigth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PRemark { get; set; }
    }
}
