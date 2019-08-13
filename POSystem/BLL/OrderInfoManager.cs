using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// OrderInfo管理类
    /// </summary>
    public class OrderInfoManager
    {
        public static OrderInfoService service = new OrderInfoService();

        #region BasicMethod
		/// <summary>
        /// 增加OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddOrderInfo(OrderInfo orderInfo)
        {
            return service.AddOrderInfo(orderInfo);
        }

        /// <summary>
        /// 删除OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteOrderInfo(OrderInfo orderInfo = null)
        {
            return service.DeleteOrderInfo(orderInfo);
        }

        /// <summary>
        /// 更新OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表更新对象</param>
        /// <param name="oldOrderInfo">orderInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateOrderInfo(OrderInfo orderInfo, OrderInfo oldOrderInfo = null)
        {
            return service.UpdateOrderInfo(orderInfo,oldOrderInfo);
        }

        /// <summary>
        /// 查询OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<OrderInfo> GetOrderInfoAll(OrderInfo orderInfo = null)
        {
            return service.GetOrderInfo(orderInfo);
        }

        /// <summary>
        /// 查询OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表查询对象</param>
        /// <returns>OrderInfo表对象</returns>
        public static OrderInfo GetOrderInfo(OrderInfo orderInfo)
        {
            return service.GetOrderInfo(orderInfo).Count > 0 ? service.GetOrderInfo(orderInfo)[0] : null;
        }

        /// <summary>
        /// 查询OrderInfo表信息是否存在
        /// </summary>
        /// <param name="orderInfo">orderInfo表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetOrderInfoBool(OrderInfo orderInfo)
        {
            return service.GetOrderInfo(orderInfo).Count > 0 ? true : false;
        }
	    #endregion

		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
