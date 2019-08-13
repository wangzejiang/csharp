using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// SubOrder管理类
    /// </summary>
    public class SubOrderManager
    {
        public static SubOrderService service = new SubOrderService();

        #region BasicMethod
		/// <summary>
        /// 增加SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddSubOrder(SubOrder subOrder)
        {
            return service.AddSubOrder(subOrder);
        }

        /// <summary>
        /// 删除SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteSubOrder(SubOrder subOrder = null)
        {
            return service.DeleteSubOrder(subOrder);
        }

        /// <summary>
        /// 更新SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表更新对象</param>
        /// <param name="oldSubOrder">subOrder表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateSubOrder(SubOrder subOrder, SubOrder oldSubOrder = null)
        {
            return service.UpdateSubOrder(subOrder,oldSubOrder);
        }

        /// <summary>
        /// 查询SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<SubOrder> GetSubOrderAll(SubOrder subOrder = null)
        {
            return service.GetSubOrder(subOrder);
        }

        /// <summary>
        /// 查询SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表查询对象</param>
        /// <returns>SubOrder表对象</returns>
        public static SubOrder GetSubOrder(SubOrder subOrder)
        {
            return service.GetSubOrder(subOrder).Count > 0 ? service.GetSubOrder(subOrder)[0] : null;
        }

        /// <summary>
        /// 查询SubOrder表信息是否存在
        /// </summary>
        /// <param name="subOrder">subOrder表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetSubOrderBool(SubOrder subOrder)
        {
            return service.GetSubOrder(subOrder).Count > 0 ? true : false;
        }
	    #endregion

		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
