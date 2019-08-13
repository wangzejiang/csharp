using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// SubOrder实体
    /// </summary>
    [Serializable]
    public class SubOrder
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public SubOrder(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public SubOrder(Object SImageID, int? SID, int? OID, DateTime? CreateDate, DateTime? UpdateDate, double? SWeigth, double? SSupplier, double? SNumber, double? SPrice, double? SSellPrice, string SName)
        {
            this.SImageID = SImageID;
            this.SID = SID;
            this.OID = OID;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.SWeigth = SWeigth;
            this.SSupplier = SSupplier;
            this.SNumber = SNumber;
            this.SPrice = SPrice;
            this.SSellPrice = SSellPrice;
            this.SName = SName;
        }

        /// <summary>
        /// 
        /// </summary>
        public Object SImageID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? SID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? OID { get; set; }

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
        public double? SWeigth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? SSupplier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? SNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? SPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? SSellPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SName { get; set; }
    }
}
