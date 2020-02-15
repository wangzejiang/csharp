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
    public class SubOrderService
    {
        #region BasicMethod
		/// <summary>
        /// 增加SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表对象</param>
        /// <returns>受影响行数</returns>
        public int AddSubOrder(SubOrder subOrder)
        {
            string sql = "insert into [SubOrder](sImageID,oID,create_date,update_date,sWeigth,sSupplier,sNumber,sPrice,sSellPrice,sName) values(@SIMAGEID,@OID,@CREATEDATE,@UPDATEDATE,@SWEIGTH,@SSUPPLIER,@SNUMBER,@SPRICE,@SSELLPRICE,@SNAME)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@SIMAGEID",subOrder.SImageID == null ? Convert.DBNull : subOrder.SImageID),
                new SqlParameter("@OID",subOrder.OID == null ? Convert.DBNull : subOrder.OID),
                new SqlParameter("@CREATEDATE",subOrder.CreateDate == null ? Convert.DBNull : subOrder.CreateDate),
                new SqlParameter("@UPDATEDATE",subOrder.UpdateDate == null ? Convert.DBNull : subOrder.UpdateDate),
                new SqlParameter("@SWEIGTH",subOrder.SWeigth == null ? Convert.DBNull : subOrder.SWeigth),
                new SqlParameter("@SSUPPLIER",subOrder.SSupplier == null ? Convert.DBNull : subOrder.SSupplier),
                new SqlParameter("@SNUMBER",subOrder.SNumber == null ? Convert.DBNull : subOrder.SNumber),
                new SqlParameter("@SPRICE",subOrder.SPrice == null ? Convert.DBNull : subOrder.SPrice),
                new SqlParameter("@SSELLPRICE",subOrder.SSellPrice == null ? Convert.DBNull : subOrder.SSellPrice),
                new SqlParameter("@SNAME",subOrder.SName == null ? Convert.DBNull : subOrder.SName)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteSubOrder(SubOrder subOrder)
        {
            string sql = "delete from [SubOrder] where 1=1";
            List<SqlParameter> paraList = GetCondition(subOrder, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表更新对象</param>
        /// <param name="oldSubOrder">subOrder表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateSubOrder(SubOrder subOrder, SubOrder oldSubOrder)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(subOrder, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldSubOrder, ref conditions);
            string sql = "update [SubOrder] set " + fields + 
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 查询SubOrder表信息
        /// </summary>
        /// <param name="subOrder">subOrder表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<SubOrder> GetSubOrder(SubOrder subOrder)
        {
            string sql = "select * from [SubOrder] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if(subOrder!=null)
            {
                paraList = GetCondition(subOrder, ref sql);
            }

            IList<SubOrder> subOrderList = new List<SubOrder>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                SubOrder obj = new SubOrder();
                obj.SImageID = Convert.IsDBNull(reader["sImageID"]) ? null : (Object)reader["sImageID"];
                obj.SID = Convert.IsDBNull(reader["sID"]) ? null : (int?)reader["sID"];
                obj.OID = Convert.IsDBNull(reader["oID"]) ? null : (int?)reader["oID"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.SWeigth = Convert.IsDBNull(reader["sWeigth"]) ? null : (decimal?)reader["sWeigth"];
                obj.SSupplier = Convert.IsDBNull(reader["sSupplier"]) ? null : (decimal?)reader["sSupplier"];
                obj.SNumber = Convert.IsDBNull(reader["sNumber"]) ? null : (decimal?)reader["sNumber"];
                obj.SPrice = Convert.IsDBNull(reader["sPrice"]) ? null : (decimal?)reader["sPrice"];
                obj.SSellPrice = Convert.IsDBNull(reader["sSellPrice"]) ? null : (decimal?)reader["sSellPrice"];
                obj.SName = Convert.IsDBNull(reader["sName"]) ? null : (string)reader["sName"];
                subOrderList.Add(obj);
            }
            reader.Close();
            return subOrderList;
        }

        private static List<SqlParameter> GetCondition(SubOrder subOrder, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (subOrder.SImageID != null)
            {
                sql += " and sImageID=@SIMAGEID";
                paraList.Add(new SqlParameter("@SIMAGEID", subOrder.SImageID));
            }
            if (subOrder.SID != null)
            {
                sql += " and sID=@SID";
                paraList.Add(new SqlParameter("@SID", subOrder.SID));
            }
            if (subOrder.OID != null)
            {
                sql += " and oID=@OID";
                paraList.Add(new SqlParameter("@OID", subOrder.OID));
            }
            if (subOrder.CreateDate != null)
            {
                sql += " and create_date=@CREATEDATE";
                paraList.Add(new SqlParameter("@CREATEDATE", subOrder.CreateDate));
            }
            if (subOrder.UpdateDate != null)
            {
                sql += " and update_date=@UPDATEDATE";
                paraList.Add(new SqlParameter("@UPDATEDATE", subOrder.UpdateDate));
            }
            if (subOrder.SWeigth != null)
            {
                sql += " and sWeigth=@SWEIGTH";
                paraList.Add(new SqlParameter("@SWEIGTH", subOrder.SWeigth));
            }
            if (subOrder.SSupplier != null)
            {
                sql += " and sSupplier=@SSUPPLIER";
                paraList.Add(new SqlParameter("@SSUPPLIER", subOrder.SSupplier));
            }
            if (subOrder.SNumber != null)
            {
                sql += " and sNumber=@SNUMBER";
                paraList.Add(new SqlParameter("@SNUMBER", subOrder.SNumber));
            }
            if (subOrder.SPrice != null)
            {
                sql += " and sPrice=@SPRICE";
                paraList.Add(new SqlParameter("@SPRICE", subOrder.SPrice));
            }
            if (subOrder.SSellPrice != null)
            {
                sql += " and sSellPrice=@SSELLPRICE";
                paraList.Add(new SqlParameter("@SSELLPRICE", subOrder.SSellPrice));
            }
            if (subOrder.SName != null)
            {
                sql += " and sName=@SNAME";
                paraList.Add(new SqlParameter("@SNAME", subOrder.SName));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(SubOrder subOrder, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            if (subOrder.SImageID != null)
            {
                fields += "sImageID=@UpdateSIMAGEID,";
                paraList.Add(new SqlParameter("@UpdateSIMAGEID", subOrder.SImageID));
            }
            if (subOrder.OID != null)
            {
                fields += "oID=@UpdateOID,";
                paraList.Add(new SqlParameter("@UpdateOID", subOrder.OID));
            }
            if (subOrder.CreateDate != null)
            {
                fields += "create_date=@UpdateCREATEDATE,";
                paraList.Add(new SqlParameter("@UpdateCREATEDATE", subOrder.CreateDate));
            }
            if (subOrder.UpdateDate != null)
            {
                fields += "update_date=@UpdateUPDATEDATE,";
                paraList.Add(new SqlParameter("@UpdateUPDATEDATE", subOrder.UpdateDate));
            }
            if (subOrder.SWeigth != null)
            {
                fields += "sWeigth=@UpdateSWEIGTH,";
                paraList.Add(new SqlParameter("@UpdateSWEIGTH", subOrder.SWeigth));
            }
            if (subOrder.SSupplier != null)
            {
                fields += "sSupplier=@UpdateSSUPPLIER,";
                paraList.Add(new SqlParameter("@UpdateSSUPPLIER", subOrder.SSupplier));
            }
            if (subOrder.SNumber != null)
            {
                fields += "sNumber=@UpdateSNUMBER,";
                paraList.Add(new SqlParameter("@UpdateSNUMBER", subOrder.SNumber));
            }
            if (subOrder.SPrice != null)
            {
                fields += "sPrice=@UpdateSPRICE,";
                paraList.Add(new SqlParameter("@UpdateSPRICE", subOrder.SPrice));
            }
            if (subOrder.SSellPrice != null)
            {
                fields += "sSellPrice=@UpdateSSELLPRICE,";
                paraList.Add(new SqlParameter("@UpdateSSELLPRICE", subOrder.SSellPrice));
            }
            if (subOrder.SName != null)
            {
                fields += "sName=@UpdateSNAME,";
                paraList.Add(new SqlParameter("@UpdateSNAME", subOrder.SName));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
	    #endregion

        #region ExtensionMethod
		 
	    #endregion
    }
}
