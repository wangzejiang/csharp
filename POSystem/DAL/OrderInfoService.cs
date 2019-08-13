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
    public class OrderInfoService
    {
        #region BasicMethod
		/// <summary>
        /// 增加OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int AddOrderInfo(OrderInfo orderInfo)
        {
            string sql = "insert into [OrderInfo](cID,uID,oStatus,oDate,create_date,update_date,oPrice,oWeigth,oFirstCost,oNumber,oRemark,oRemark2) values(@CID,@UID,@OSTATUS,@ODATE,@CREATEDATE,@UPDATEDATE,@OPRICE,@OWEIGTH,@OFIRSTCOST,@ONUMBER,@OREMARK,@OREMARK2)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@CID",orderInfo.CID == null ? Convert.DBNull : orderInfo.CID),
                new SqlParameter("@UID",orderInfo.UID == null ? Convert.DBNull : orderInfo.UID),
                new SqlParameter("@OSTATUS",orderInfo.OStatus == null ? Convert.DBNull : orderInfo.OStatus),
                new SqlParameter("@ODATE",orderInfo.ODate == null ? Convert.DBNull : orderInfo.ODate),
                new SqlParameter("@CREATEDATE",orderInfo.CreateDate == null ? Convert.DBNull : orderInfo.CreateDate),
                new SqlParameter("@UPDATEDATE",orderInfo.UpdateDate == null ? Convert.DBNull : orderInfo.UpdateDate),
                new SqlParameter("@OPRICE",orderInfo.OPrice == null ? Convert.DBNull : orderInfo.OPrice),
                new SqlParameter("@OWEIGTH",orderInfo.OWeigth == null ? Convert.DBNull : orderInfo.OWeigth),
                new SqlParameter("@OFIRSTCOST",orderInfo.OFirstCost == null ? Convert.DBNull : orderInfo.OFirstCost),
                new SqlParameter("@ONUMBER",orderInfo.ONumber == null ? Convert.DBNull : orderInfo.ONumber),
                new SqlParameter("@OREMARK",orderInfo.ORemark == null ? Convert.DBNull : orderInfo.ORemark),
                new SqlParameter("@OREMARK2",orderInfo.ORemark2 == null ? Convert.DBNull : orderInfo.ORemark2)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteOrderInfo(OrderInfo orderInfo)
        {
            string sql = "delete from [OrderInfo] where 1=1";
            List<SqlParameter> paraList = GetCondition(orderInfo, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表更新对象</param>
        /// <param name="oldOrderInfo">orderInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateOrderInfo(OrderInfo orderInfo, OrderInfo oldOrderInfo)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(orderInfo, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldOrderInfo, ref conditions);
            string sql = "update [OrderInfo] set " + fields + 
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 查询OrderInfo表信息
        /// </summary>
        /// <param name="orderInfo">orderInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<OrderInfo> GetOrderInfo(OrderInfo orderInfo)
        {
            string sql = "select * from [OrderInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if(orderInfo!=null)
            {
                paraList = GetCondition(orderInfo, ref sql);
            }

            IList<OrderInfo> orderInfoList = new List<OrderInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                OrderInfo obj = new OrderInfo();
                obj.OID = Convert.IsDBNull(reader["oID"]) ? null : (int?)reader["oID"];
                obj.CID = Convert.IsDBNull(reader["cID"]) ? null : (int?)reader["cID"];
                obj.UID = Convert.IsDBNull(reader["uID"]) ? null : (int?)reader["uID"];
                obj.OStatus = Convert.IsDBNull(reader["oStatus"]) ? null : (int?)reader["oStatus"];
                obj.ODate = Convert.IsDBNull(reader["oDate"]) ? null : (DateTime?)reader["oDate"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.OPrice = Convert.IsDBNull(reader["oPrice"]) ? null : (double?)reader["oPrice"];
                obj.OWeigth = Convert.IsDBNull(reader["oWeigth"]) ? null : (double?)reader["oWeigth"];
                obj.OFirstCost = Convert.IsDBNull(reader["oFirstCost"]) ? null : (double?)reader["oFirstCost"];
                obj.ONumber = Convert.IsDBNull(reader["oNumber"]) ? null : (string)reader["oNumber"];
                obj.ORemark = Convert.IsDBNull(reader["oRemark"]) ? null : (string)reader["oRemark"];
                obj.ORemark2 = Convert.IsDBNull(reader["oRemark2"]) ? null : (string)reader["oRemark2"];
                orderInfoList.Add(obj);
            }
            reader.Close();
            return orderInfoList;
        }

        private static List<SqlParameter> GetCondition(OrderInfo orderInfo, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (orderInfo.OID != null)
            {
                sql += " and oID=@OID";
                paraList.Add(new SqlParameter("@OID", orderInfo.OID));
            }
            if (orderInfo.CID != null)
            {
                sql += " and cID=@CID";
                paraList.Add(new SqlParameter("@CID", orderInfo.CID));
            }
            if (orderInfo.UID != null)
            {
                sql += " and uID=@UID";
                paraList.Add(new SqlParameter("@UID", orderInfo.UID));
            }
            if (orderInfo.OStatus != null)
            {
                sql += " and oStatus=@OSTATUS";
                paraList.Add(new SqlParameter("@OSTATUS", orderInfo.OStatus));
            }
            if (orderInfo.ODate != null)
            {
                sql += " and oDate=@ODATE";
                paraList.Add(new SqlParameter("@ODATE", orderInfo.ODate));
            }
            if (orderInfo.CreateDate != null)
            {
                sql += " and create_date=@CREATEDATE";
                paraList.Add(new SqlParameter("@CREATEDATE", orderInfo.CreateDate));
            }
            if (orderInfo.UpdateDate != null)
            {
                sql += " and update_date=@UPDATEDATE";
                paraList.Add(new SqlParameter("@UPDATEDATE", orderInfo.UpdateDate));
            }
            if (orderInfo.OPrice != null)
            {
                sql += " and oPrice=@OPRICE";
                paraList.Add(new SqlParameter("@OPRICE", orderInfo.OPrice));
            }
            if (orderInfo.OWeigth != null)
            {
                sql += " and oWeigth=@OWEIGTH";
                paraList.Add(new SqlParameter("@OWEIGTH", orderInfo.OWeigth));
            }
            if (orderInfo.OFirstCost != null)
            {
                sql += " and oFirstCost=@OFIRSTCOST";
                paraList.Add(new SqlParameter("@OFIRSTCOST", orderInfo.OFirstCost));
            }
            if (orderInfo.ONumber != null)
            {
                sql += " and oNumber=@ONUMBER";
                paraList.Add(new SqlParameter("@ONUMBER", orderInfo.ONumber));
            }
            if (orderInfo.ORemark != null)
            {
                sql += " and oRemark=@OREMARK";
                paraList.Add(new SqlParameter("@OREMARK", orderInfo.ORemark));
            }
            if (orderInfo.ORemark2 != null)
            {
                sql += " and oRemark2=@OREMARK2";
                paraList.Add(new SqlParameter("@OREMARK2", orderInfo.ORemark2));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(OrderInfo orderInfo, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            if (orderInfo.CID != null)
            {
                fields += "cID=@UpdateCID,";
                paraList.Add(new SqlParameter("@UpdateCID", orderInfo.CID));
            }
            if (orderInfo.UID != null)
            {
                fields += "uID=@UpdateUID,";
                paraList.Add(new SqlParameter("@UpdateUID", orderInfo.UID));
            }
            if (orderInfo.OStatus != null)
            {
                fields += "oStatus=@UpdateOSTATUS,";
                paraList.Add(new SqlParameter("@UpdateOSTATUS", orderInfo.OStatus));
            }
            if (orderInfo.ODate != null)
            {
                fields += "oDate=@UpdateODATE,";
                paraList.Add(new SqlParameter("@UpdateODATE", orderInfo.ODate));
            }
            if (orderInfo.CreateDate != null)
            {
                fields += "create_date=@UpdateCREATEDATE,";
                paraList.Add(new SqlParameter("@UpdateCREATEDATE", orderInfo.CreateDate));
            }
            if (orderInfo.UpdateDate != null)
            {
                fields += "update_date=@UpdateUPDATEDATE,";
                paraList.Add(new SqlParameter("@UpdateUPDATEDATE", orderInfo.UpdateDate));
            }
            if (orderInfo.OPrice != null)
            {
                fields += "oPrice=@UpdateOPRICE,";
                paraList.Add(new SqlParameter("@UpdateOPRICE", orderInfo.OPrice));
            }
            if (orderInfo.OWeigth != null)
            {
                fields += "oWeigth=@UpdateOWEIGTH,";
                paraList.Add(new SqlParameter("@UpdateOWEIGTH", orderInfo.OWeigth));
            }
            if (orderInfo.OFirstCost != null)
            {
                fields += "oFirstCost=@UpdateOFIRSTCOST,";
                paraList.Add(new SqlParameter("@UpdateOFIRSTCOST", orderInfo.OFirstCost));
            }
            if (orderInfo.ONumber != null)
            {
                fields += "oNumber=@UpdateONUMBER,";
                paraList.Add(new SqlParameter("@UpdateONUMBER", orderInfo.ONumber));
            }
            if (orderInfo.ORemark != null)
            {
                fields += "oRemark=@UpdateOREMARK,";
                paraList.Add(new SqlParameter("@UpdateOREMARK", orderInfo.ORemark));
            }
            if (orderInfo.ORemark2 != null)
            {
                fields += "oRemark2=@UpdateOREMARK2,";
                paraList.Add(new SqlParameter("@UpdateOREMARK2", orderInfo.ORemark2));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
	    #endregion

        #region ExtensionMethod
		 
	    #endregion
    }
}
