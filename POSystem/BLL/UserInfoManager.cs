using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// UserInfo管理类
    /// </summary>
    public class UserInfoManager
    {
        public static UserInfoService service = new UserInfoService();

        #region BasicMethod
		/// <summary>
        /// 增加UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddUserInfo(UserInfo userInfo)
        {
            return service.AddUserInfo(userInfo);
        }

        /// <summary>
        /// 删除UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteUserInfo(UserInfo userInfo = null)
        {
            return service.DeleteUserInfo(userInfo);
        }

        /// <summary>
        /// 更新UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表更新对象</param>
        /// <param name="oldUserInfo">userInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateUserInfo(UserInfo userInfo, UserInfo oldUserInfo = null)
        {
            return service.UpdateUserInfo(userInfo,oldUserInfo);
        }

        /// <summary>
        /// 查询UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<UserInfo> GetUserInfoAll(UserInfo userInfo = null)
        {
            return service.GetUserInfo(userInfo);
        }

        /// <summary>
        /// 查询UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表查询对象</param>
        /// <returns>UserInfo表对象</returns>
        public static UserInfo GetUserInfo(UserInfo userInfo)
        {
            return service.GetUserInfo(userInfo).Count > 0 ? service.GetUserInfo(userInfo)[0] : null;
        }

        /// <summary>
        /// 查询UserInfo表信息是否存在
        /// </summary>
        /// <param name="userInfo">userInfo表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetUserInfoBool(UserInfo userInfo)
        {
            return service.GetUserInfo(userInfo).Count > 0 ? true : false;
        }
	    #endregion

		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
