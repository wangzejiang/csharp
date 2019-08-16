using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// OrderProductInfo管理类
    /// </summary>
    public class OrderProductInfoManager
    {
        public static OrderProductInfoService service = new OrderProductInfoService();

        #region BasicMethod
		/// <summary>
        /// 增加OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddOrderProductInfo(OrderProductInfo orderProductInfo)
        {
            return service.AddOrderProductInfo(orderProductInfo);
        }

        /// <summary>
        /// 删除OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteOrderProductInfo(OrderProductInfo orderProductInfo = null)
        {
            return service.DeleteOrderProductInfo(orderProductInfo);
        }

        /// <summary>
        /// 更新OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表更新对象</param>
        /// <param name="oldOrderProductInfo">orderProductInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateOrderProductInfo(OrderProductInfo orderProductInfo, OrderProductInfo oldOrderProductInfo = null)
        {
            return service.UpdateOrderProductInfo(orderProductInfo,oldOrderProductInfo);
        }

        /// <summary>
        /// 查询OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<OrderProductInfo> GetOrderProductInfoAll(OrderProductInfo orderProductInfo = null)
        {
            return service.GetOrderProductInfo(orderProductInfo);
        }

        /// <summary>
        /// 查询OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表查询对象</param>
        /// <returns>OrderProductInfo表对象</returns>
        public static OrderProductInfo GetOrderProductInfo(OrderProductInfo orderProductInfo)
        {
            return service.GetOrderProductInfo(orderProductInfo).Count > 0 ? service.GetOrderProductInfo(orderProductInfo)[0] : null;
        }
        public static OrderProductInfo GetOrderProductMinPrice(OrderProductInfo orderProductInfo)
        {
            return service.GetOrderProductMinPrice(orderProductInfo).Count > 0 ? service.GetOrderProductMinPrice(orderProductInfo)[0] : null;
        }
        /// <summary>
        /// 查询OrderProductInfo表信息是否存在
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetOrderProductInfoBool(OrderProductInfo orderProductInfo)
        {
            return service.GetOrderProductInfo(orderProductInfo).Count > 0 ? true : false;
        }
	    #endregion

		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
