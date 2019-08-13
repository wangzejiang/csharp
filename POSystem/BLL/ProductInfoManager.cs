using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// ProductInfo管理类
    /// </summary>
    public class ProductInfoManager
    {
        public static ProductInfoService service = new ProductInfoService();

        #region BasicMethod
        /// <summary>
        /// 增加ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddProductInfo(ProductInfo productInfo)
        {
            return service.AddProductInfo(productInfo);
        }

        /// <summary>
        /// 删除ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteProductInfo(ProductInfo productInfo = null)
        {
            return service.DeleteProductInfo(productInfo);
        }

        /// <summary>
        /// 更新ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表更新对象</param>
        /// <param name="oldProductInfo">productInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateProductInfo(ProductInfo productInfo, ProductInfo oldProductInfo = null)
        {
            return service.UpdateProductInfo(productInfo,oldProductInfo);
        }

        /// <summary>
        /// 查询ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<ProductInfo> GetProductInfoAll(ProductInfo productInfo = null)
        {
            return service.GetProductInfo(productInfo);
        }

        /// <summary>
        /// 查询ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<ProductInfo> GetProductInfoAll2(ProductInfo productInfo = null)
        {
            return service.GetProductInfo2(productInfo);
        }

        /// <summary>
        /// 查询ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表查询对象</param>
        /// <returns>ProductInfo表对象</returns>
        public static ProductInfo GetProductInfo(ProductInfo productInfo)
        {
            return service.GetProductInfo(productInfo).Count > 0 ? service.GetProductInfo(productInfo)[0] : null;
        }

        /// <summary>
        /// 查询ProductInfo表信息是否存在
        /// </summary>
        /// <param name="productInfo">productInfo表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetProductInfoBool(ProductInfo productInfo)
        {
            return service.GetProductInfo(productInfo).Count > 0 ? true : false;
        }

        public static int AddProductInfo(ProductInfo pInfo, Attachment attachment)
        {
            attachment.ID = pInfo.PImageID;
            int idx = AttachmentManager.AddAttachment(attachment);
            if(idx > 0)
            {
                return service.AddProductInfo(pInfo);
            }
            return 0;
        }
        #endregion

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
