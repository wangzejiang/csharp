using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using System.Data.SqlClient;
using POSystem.DBUtility;
using System.Data;

namespace POSystem.DAL
{
    public class UserInfoService
    {
        #region BasicMethod
		/// <summary>
        /// 增加UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int AddUserInfo(UserInfo userInfo)
        {
            string sql = "insert into [UserInfo](create_date,update_date,uName,uPassword,attr1,attr2,attr3,attr4,attr5,attr6) "+
                "values(@CREATEDATE,@UPDATEDATE,@UNAME,@UPASSWORD,@ATTR1,@ATTR2,@ATTR3,@ATTR4,@ATTR5,@ATTR6)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@CREATEDATE",userInfo.CreateDate == null ? Convert.DBNull : userInfo.CreateDate),
                new SqlParameter("@UPDATEDATE",userInfo.UpdateDate == null ? Convert.DBNull : userInfo.UpdateDate),
                new SqlParameter("@UNAME",userInfo.UName == null ? Convert.DBNull : userInfo.UName),
                new SqlParameter("@UPASSWORD",userInfo.UPassword == null ? Convert.DBNull : userInfo.UPassword),
                new SqlParameter("@ATTR1",userInfo.Attr1 == null ? Convert.DBNull : userInfo.Attr1),
                new SqlParameter("@ATTR2",userInfo.Attr2 == null ? Convert.DBNull : userInfo.Attr2),
                new SqlParameter("@ATTR3",userInfo.Attr3 == null ? Convert.DBNull : userInfo.Attr3),
                new SqlParameter("@ATTR4",userInfo.Attr4 == null ? Convert.DBNull : userInfo.Attr4),
                new SqlParameter("@ATTR5",userInfo.Attr5 == null ? Convert.DBNull : userInfo.Attr5),
                new SqlParameter("@ATTR6",userInfo.Attr6 == null ? Convert.DBNull : userInfo.Attr6)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteUserInfo(UserInfo userInfo)
        {
            string sql = "delete from [UserInfo] where 1=1";
            List<SqlParameter> paraList = GetCondition(userInfo, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表更新对象</param>
        /// <param name="oldUserInfo">userInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateUserInfo(UserInfo userInfo, UserInfo oldUserInfo)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(userInfo, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldUserInfo, ref conditions);
            string sql = "update [UserInfo] set " + fields + 
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 查询UserInfo表信息
        /// </summary>
        /// <param name="userInfo">userInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<UserInfo> GetUserInfo(UserInfo userInfo)
        {
            string sql = "select top 100 * from [UserInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if(userInfo!=null)
            {
                paraList = GetCondition(userInfo, ref sql);
            }

            IList<UserInfo> userInfoList = new List<UserInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                UserInfo obj = new UserInfo();
                obj.UID = Convert.IsDBNull(reader["uID"]) ? null : (int?)reader["uID"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.UName = Convert.IsDBNull(reader["uName"]) ? null : (string)reader["uName"];
                obj.UPassword = Convert.IsDBNull(reader["uPassword"]) ? null : (string)reader["uPassword"];
                obj.Attr1 = Convert.IsDBNull(reader["attr1"]) ? null : (string)reader["attr1"];
                obj.Attr2 = Convert.IsDBNull(reader["attr2"]) ? null : (string)reader["attr2"];
                obj.Attr3 = Convert.IsDBNull(reader["attr3"]) ? null : (string)reader["attr3"];
                obj.Attr4 = Convert.IsDBNull(reader["attr4"]) ? null : (string)reader["attr4"];
                obj.Attr5 = Convert.IsDBNull(reader["attr5"]) ? null : (string)reader["attr5"];
                obj.Attr6 = Convert.IsDBNull(reader["attr6"]) ? null : (string)reader["attr6"];
                userInfoList.Add(obj);
            }
            reader.Close();
            return userInfoList;
        }

        private static List<SqlParameter> GetCondition(UserInfo userInfo, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (userInfo.UID != null)
            {
                sql += " and uID=@UID";
                paraList.Add(new SqlParameter("@UID", userInfo.UID));
            }
            if (userInfo.CreateDate != null)
            {
                sql += " and create_date=@CREATEDATE";
                paraList.Add(new SqlParameter("@CREATEDATE", userInfo.CreateDate));
            }
            if (userInfo.UpdateDate != null)
            {
                sql += " and update_date=@UPDATEDATE";
                paraList.Add(new SqlParameter("@UPDATEDATE", userInfo.UpdateDate));
            }
            if (userInfo.UName != null)
            {
                sql += " and uName=@UNAME";
                paraList.Add(new SqlParameter("@UNAME", userInfo.UName));
            }
            if (userInfo.UPassword != null)
            {
                sql += " and uPassword=@UPASSWORD";
                paraList.Add(new SqlParameter("@UPASSWORD", userInfo.UPassword));
            }
            if (userInfo.Attr1 != null)
            {
                sql += " and attr1=@ATTR1";
                paraList.Add(new SqlParameter("@ATTR1", userInfo.Attr1));
            }
            if (userInfo.Attr2 != null)
            {
                sql += " and attr2=@ATTR2";
                paraList.Add(new SqlParameter("@ATTR2", userInfo.Attr2));
            }
            if (userInfo.Attr3 != null)
            {
                sql += " and attr3=@ATTR3";
                paraList.Add(new SqlParameter("@ATTR3", userInfo.Attr3));
            }
            if (userInfo.Attr4 != null)
            {
                sql += " and attr4=@ATTR4";
                paraList.Add(new SqlParameter("@ATTR4", userInfo.Attr4));
            }
            if (userInfo.Attr5 != null)
            {
                sql += " and attr5=@ATTR5";
                paraList.Add(new SqlParameter("@ATTR5", userInfo.Attr5));
            }
            if (userInfo.Attr6 != null)
            {
                sql += " and attr6=@ATTR6";
                paraList.Add(new SqlParameter("@ATTR6", userInfo.Attr6));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(UserInfo userInfo, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            if (userInfo.CreateDate != null)
            {
                fields += "create_date=@UpdateCREATEDATE,";
                paraList.Add(new SqlParameter("@UpdateCREATEDATE", userInfo.CreateDate));
            }
            if (userInfo.UpdateDate != null)
            {
                fields += "update_date=@UpdateUPDATEDATE,";
                paraList.Add(new SqlParameter("@UpdateUPDATEDATE", userInfo.UpdateDate));
            }
            if (userInfo.UName != null)
            {
                fields += "uName=@UpdateUNAME,";
                paraList.Add(new SqlParameter("@UpdateUNAME", userInfo.UName));
            }
            if (userInfo.UPassword != null)
            {
                fields += "uPassword=@UpdateUPASSWORD,";
                paraList.Add(new SqlParameter("@UpdateUPASSWORD", userInfo.UPassword));
            }
            if (userInfo.Attr1 != null)
            {
                fields += "attr1=@UpdateATTR1,";
                paraList.Add(new SqlParameter("@UpdateATTR1", userInfo.Attr1));
            }
            if (userInfo.Attr2 != null)
            {
                fields += "attr2=@UpdateATTR2,";
                paraList.Add(new SqlParameter("@UpdateATTR2", userInfo.Attr2));
            }
            if (userInfo.Attr3 != null)
            {
                fields += "attr3=@UpdateATTR3,";
                paraList.Add(new SqlParameter("@UpdateATTR3", userInfo.Attr3));
            }
            if (userInfo.Attr4 != null)
            {
                fields += "attr4=@UpdateATTR4,";
                paraList.Add(new SqlParameter("@UpdateATTR4", userInfo.Attr4));
            }
            if (userInfo.Attr5 != null)
            {
                fields += "attr5=@UpdateATTR5,";
                paraList.Add(new SqlParameter("@UpdateATTR5", userInfo.Attr5));
            }
            if (userInfo.Attr6 != null)
            {
                fields += "attr6=@UpdateATTR6,";
                paraList.Add(new SqlParameter("@UpdateATTR6", userInfo.Attr6));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
	    #endregion

        #region ExtensionMethod
		 
	    #endregion
    }
}
