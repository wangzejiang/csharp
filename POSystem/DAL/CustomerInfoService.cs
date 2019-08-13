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
    public class CustomerInfoService
    {
        #region BasicMethod
		/// <summary>
        /// 增加CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int AddCustomerInfo(CustomerInfo customerInfo)
        {
            string sql = "insert into [CustomerInfo](create_date,update_date,cName,cPhone,cAddress) values(@CREATEDATE,@UPDATEDATE,@CNAME,@CPHONE,@CADDRESS)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@CREATEDATE",customerInfo.CreateDate == null ? Convert.DBNull : customerInfo.CreateDate),
                new SqlParameter("@UPDATEDATE",customerInfo.UpdateDate == null ? Convert.DBNull : customerInfo.UpdateDate),
                new SqlParameter("@CNAME",customerInfo.CName == null ? Convert.DBNull : customerInfo.CName),
                new SqlParameter("@CPHONE",customerInfo.CPhone == null ? Convert.DBNull : customerInfo.CPhone),
                new SqlParameter("@CADDRESS",customerInfo.CAddress == null ? Convert.DBNull : customerInfo.CAddress)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteCustomerInfo(CustomerInfo customerInfo)
        {
            string sql = "delete from [CustomerInfo] where 1=1";
            List<SqlParameter> paraList = GetCondition(customerInfo, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表更新对象</param>
        /// <param name="oldCustomerInfo">customerInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateCustomerInfo(CustomerInfo customerInfo, CustomerInfo oldCustomerInfo)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(customerInfo, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldCustomerInfo, ref conditions);
            string sql = "update [CustomerInfo] set " + fields + 
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 查询CustomerInfo表信息
        /// </summary>
        /// <param name="customerInfo">customerInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<CustomerInfo> GetCustomerInfo(CustomerInfo customerInfo)
        {
            string sql = "select * from [CustomerInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if(customerInfo!=null)
            {
                paraList = GetCondition(customerInfo, ref sql);
            }

            IList<CustomerInfo> customerInfoList = new List<CustomerInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                CustomerInfo obj = new CustomerInfo();
                obj.CID = Convert.IsDBNull(reader["cID"]) ? null : (int?)reader["cID"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.CName = Convert.IsDBNull(reader["cName"]) ? null : (string)reader["cName"];
                obj.CPhone = Convert.IsDBNull(reader["cPhone"]) ? null : (string)reader["cPhone"];
                obj.CAddress = Convert.IsDBNull(reader["cAddress"]) ? null : (string)reader["cAddress"];
                customerInfoList.Add(obj);
            }
            reader.Close();
            return customerInfoList;
        }

        private static List<SqlParameter> GetCondition(CustomerInfo customerInfo, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (customerInfo.CID != null)
            {
                sql += " and cID=@CID";
                paraList.Add(new SqlParameter("@CID", customerInfo.CID));
            }
            if (customerInfo.CreateDate != null)
            {
                sql += " and create_date=@CREATEDATE";
                paraList.Add(new SqlParameter("@CREATEDATE", customerInfo.CreateDate));
            }
            if (customerInfo.UpdateDate != null)
            {
                sql += " and update_date=@UPDATEDATE";
                paraList.Add(new SqlParameter("@UPDATEDATE", customerInfo.UpdateDate));
            }
            if (customerInfo.CName != null)
            {
                sql += " and cName=@CNAME";
                paraList.Add(new SqlParameter("@CNAME", customerInfo.CName));
            }
            if (customerInfo.CPhone != null)
            {
                sql += " and cPhone=@CPHONE";
                paraList.Add(new SqlParameter("@CPHONE", customerInfo.CPhone));
            }
            if (customerInfo.CAddress != null)
            {
                sql += " and cAddress=@CADDRESS";
                paraList.Add(new SqlParameter("@CADDRESS", customerInfo.CAddress));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(CustomerInfo customerInfo, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            if (customerInfo.CreateDate != null)
            {
                fields += "create_date=@UpdateCREATEDATE,";
                paraList.Add(new SqlParameter("@UpdateCREATEDATE", customerInfo.CreateDate));
            }
            if (customerInfo.UpdateDate != null)
            {
                fields += "update_date=@UpdateUPDATEDATE,";
                paraList.Add(new SqlParameter("@UpdateUPDATEDATE", customerInfo.UpdateDate));
            }
            if (customerInfo.CName != null)
            {
                fields += "cName=@UpdateCNAME,";
                paraList.Add(new SqlParameter("@UpdateCNAME", customerInfo.CName));
            }
            if (customerInfo.CPhone != null)
            {
                fields += "cPhone=@UpdateCPHONE,";
                paraList.Add(new SqlParameter("@UpdateCPHONE", customerInfo.CPhone));
            }
            if (customerInfo.CAddress != null)
            {
                fields += "cAddress=@UpdateCADDRESS,";
                paraList.Add(new SqlParameter("@UpdateCADDRESS", customerInfo.CAddress));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
	    #endregion

        #region ExtensionMethod
		 
	    #endregion
    }
}
