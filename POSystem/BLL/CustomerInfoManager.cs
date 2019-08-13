using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// CustomerInfo管理类
    /// </summary>
    public class CustomerInfoManager
    {
        public static CustomerInfoService service = new CustomerInfoService();

        #region BasicMethod
		/// <summary>
        /// 增加CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddCustomerInfo(CustomerInfo customerInfo)
        {
            return service.AddCustomerInfo(customerInfo);
        }

        /// <summary>
        /// 删除CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteCustomerInfo(CustomerInfo customerInfo = null)
        {
            return service.DeleteCustomerInfo(customerInfo);
        }

        /// <summary>
        /// 更新CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表更新对象</param>
        /// <param name="oldCustomerInfo">customerInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateCustomerInfo(CustomerInfo customerInfo, CustomerInfo oldCustomerInfo = null)
        {
            return service.UpdateCustomerInfo(customerInfo,oldCustomerInfo);
        }

        /// <summary>
        /// 查询CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<CustomerInfo> GetCustomerInfoAll(CustomerInfo customerInfo = null)
        {
            return service.GetCustomerInfo(customerInfo);
        }

        /// <summary>
        /// 查询CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表查询对象</param>
        /// <returns>CustomerInfo表对象</returns>
        public static CustomerInfo GetCustomerInfo(CustomerInfo customerInfo)
        {
            return service.GetCustomerInfo(customerInfo).Count > 0 ? service.GetCustomerInfo(customerInfo)[0] : null;
        }

        /// <summary>
        /// 查询CustomerInfo表信息是否存在
        /// </summary>
        /// <param name="customerInfo">customerInfo表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetCustomerInfoBool(CustomerInfo customerInfo)
        {
            return service.GetCustomerInfo(customerInfo).Count > 0 ? true : false;
        }
	    #endregion

		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
