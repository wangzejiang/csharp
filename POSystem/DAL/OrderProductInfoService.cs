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
    public class OrderProductInfoService
    {
        #region BasicMethod
        /// <summary>
        /// 增加OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int AddOrderProductInfo(OrderProductInfo orderProductInfo)
        {
            //string sql = "insert into [OrderProductInfo](opImageID,oID,cID,oNumber,update_date,create_date,opPrice,opWeigth,opCount,opPriceX,opName,opNumber,opSuppliter,opRemark) values(@OPIMAGEID,@OID,@CID,@ONUMBER,@UPDATEDATE,@CREATEDATE,@OPPRICE,@OPWEIGTH,@OPCOUNT,@OPPRICEX,@OPNAME,@OPNUMBER,@OPSUPPLITER,@OPREMARK)";
            string sql = "insert into [OrderProductInfo](opImageID,oID,pID,cID,oNumber,opPrice,opWeigth,opCount,opPriceX,opName,opNumber,opSuppliter,opRemark) values(@OPIMAGEID,@OID,@PID,@CID,@ONUMBER,@OPPRICE,@OPWEIGTH,@OPCOUNT,@OPPRICEX,@OPNAME,@OPNUMBER,@OPSUPPLITER,@OPREMARK)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@OPIMAGEID",orderProductInfo.OpImageID == null ? Convert.DBNull : orderProductInfo.OpImageID),
                new SqlParameter("@OID",orderProductInfo.OID == null ? Convert.DBNull : orderProductInfo.OID),
                new SqlParameter("@PID",orderProductInfo.PID == null ? Convert.DBNull : orderProductInfo.PID),
                new SqlParameter("@CID",orderProductInfo.CID == null ? Convert.DBNull : orderProductInfo.CID),
                new SqlParameter("@ONUMBER",orderProductInfo.ONumber == null ? Convert.DBNull : orderProductInfo.ONumber),
                //new SqlParameter("@UPDATEDATE",orderProductInfo.UpdateDate == null ? Convert.DBNull : orderProductInfo.UpdateDate),
                //new SqlParameter("@CREATEDATE",orderProductInfo.CreateDate == null ? Convert.DBNull : orderProductInfo.CreateDate),
                new SqlParameter("@OPPRICE",orderProductInfo.OpPrice == null ? Convert.DBNull : orderProductInfo.OpPrice),
                new SqlParameter("@OPWEIGTH",orderProductInfo.OpWeigth == null ? Convert.DBNull : orderProductInfo.OpWeigth),
                new SqlParameter("@OPCOUNT",orderProductInfo.OpCount == null ? Convert.DBNull : orderProductInfo.OpCount),
                new SqlParameter("@OPPRICEX",orderProductInfo.OpPriceX == null ? Convert.DBNull : orderProductInfo.OpPriceX),
                new SqlParameter("@OPNAME",orderProductInfo.OpName == null ? Convert.DBNull : orderProductInfo.OpName),
                new SqlParameter("@OPNUMBER",orderProductInfo.OpNumber == null ? Convert.DBNull : orderProductInfo.OpNumber),
                new SqlParameter("@OPSUPPLITER",orderProductInfo.OpSuppliter == null ? Convert.DBNull : orderProductInfo.OpSuppliter),
                new SqlParameter("@OPREMARK",orderProductInfo.OpRemark == null ? Convert.DBNull : orderProductInfo.OpRemark)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteOrderProductInfo(OrderProductInfo orderProductInfo)
        {
            string sql = "delete from [OrderProductInfo] where 1=1";
            List<SqlParameter> paraList = GetCondition(orderProductInfo, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表更新对象</param>
        /// <param name="oldOrderProductInfo">orderProductInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateOrderProductInfo(OrderProductInfo orderProductInfo, OrderProductInfo oldOrderProductInfo)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(orderProductInfo, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldOrderProductInfo, ref conditions);
            string sql = "update [OrderProductInfo] set " + fields +
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }
        
        public IList<OrderProductInfo> GetOrderProductMinPrice(OrderProductInfo orderProductInfo)
        {
            string sql = "select * from [OrderProductInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (orderProductInfo != null)
            {
                paraList = GetCondition(orderProductInfo, ref sql);
            }
            sql += " order by create_date desc";
            IList<OrderProductInfo> orderProductInfoList = new List<OrderProductInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                orderProductInfoList.Add(createOP(reader));
            }
            reader.Close();
            return orderProductInfoList;
        }

        private OrderProductInfo createOP(SqlDataReader reader)
        {
            OrderProductInfo obj = new OrderProductInfo();
            obj.OpImageID = Convert.IsDBNull(reader["opImageID"]) ? null : (Object)reader["opImageID"];
            obj.OpID = Convert.IsDBNull(reader["opID"]) ? null : (int?)reader["opID"];
            obj.OID = Convert.IsDBNull(reader["oID"]) ? null : (int?)reader["oID"]; // aaa
            obj.CID = Convert.IsDBNull(reader["cID"]) ? null : (int?)reader["cID"]; // aaa
            obj.PID = Convert.IsDBNull(reader["pID"]) ? null : (int?)reader["pID"]; // aaa
            obj.ONumber = Convert.IsDBNull(reader["oNumber"]) ? null : (string)reader["oNumber"];   // aaa
            obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
            obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
            obj.OpPrice = Convert.IsDBNull(reader["opPrice"]) ? null : (decimal?)reader["opPrice"];
            obj.OpWeigth = Convert.IsDBNull(reader["opWeigth"]) ? null : (decimal?)reader["opWeigth"];
            obj.OpCount = Convert.IsDBNull(reader["opCount"]) ? null : (decimal?)reader["opCount"];
            obj.OpPriceX = Convert.IsDBNull(reader["opPriceX"]) ? null : (decimal?)reader["opPriceX"];
            obj.OpName = Convert.IsDBNull(reader["opName"]) ? null : (string)reader["opName"];
            obj.OpNumber = Convert.IsDBNull(reader["opNumber"]) ? null : (string)reader["opNumber"];
            obj.OpSuppliter = Convert.IsDBNull(reader["opSuppliter"]) ? null : (string)reader["opSuppliter"];
            obj.OpRemark = Convert.IsDBNull(reader["opRemark"]) ? null : (string)reader["opRemark"];
            return obj;
        }
        /// <summary>
        /// 查询OrderProductInfo表信息
        /// </summary>
        /// <param name="orderProductInfo">orderProductInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<OrderProductInfo> GetOrderProductInfo(OrderProductInfo orderProductInfo)
        {
            string sql = "select * from [OrderProductInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (orderProductInfo != null)
            {
                paraList = GetCondition(orderProductInfo, ref sql);
            }

            IList<OrderProductInfo> orderProductInfoList = new List<OrderProductInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                orderProductInfoList.Add(createOP(reader));
            }
            reader.Close();
            return orderProductInfoList;
        }

        private static List<SqlParameter> GetCondition(OrderProductInfo orderProductInfo, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (orderProductInfo.OpImageID != null)
            {
                sql += " and opImageID=@OPIMAGEID";
                paraList.Add(new SqlParameter("@OPIMAGEID", orderProductInfo.OpImageID));
            }
            if (orderProductInfo.OpID != null)
            {
                sql += " and opID=@OPID";
                paraList.Add(new SqlParameter("@OPID", orderProductInfo.OpID));
            }
            if (orderProductInfo.PID != null)
            {
                sql += " and pID=@PID";
                paraList.Add(new SqlParameter("@PID", orderProductInfo.PID));
            }
            if (orderProductInfo.OID != null)
            {
                sql += " and oID=@OID";
                paraList.Add(new SqlParameter("@OID", orderProductInfo.OID));
            }
            if (orderProductInfo.CID != null)
            {
                sql += " and cID=@CID";
                paraList.Add(new SqlParameter("@CID", orderProductInfo.CID));
            }
            if (orderProductInfo.ONumber != null)
            {
                sql += " and oNumber=@ONUMBER";
                paraList.Add(new SqlParameter("@ONUMBER", orderProductInfo.ONumber));
            }
            if (orderProductInfo.UpdateDate != null)
            {
                sql += " and update_date=@UPDATEDATE";
                paraList.Add(new SqlParameter("@UPDATEDATE", orderProductInfo.UpdateDate));
            }
            if (orderProductInfo.CreateDate != null)
            {
                sql += " and create_date=@CREATEDATE";
                paraList.Add(new SqlParameter("@CREATEDATE", orderProductInfo.CreateDate));
            }
            if (orderProductInfo.OpPrice != null)
            {
                sql += " and opPrice=@OPPRICE";
                paraList.Add(new SqlParameter("@OPPRICE", orderProductInfo.OpPrice));
            }
            if (orderProductInfo.OpWeigth != null)
            {
                sql += " and opWeigth=@OPWEIGTH";
                paraList.Add(new SqlParameter("@OPWEIGTH", orderProductInfo.OpWeigth));
            }
            if (orderProductInfo.OpCount != null)
            {
                sql += " and opCount=@OPCOUNT";
                paraList.Add(new SqlParameter("@OPCOUNT", orderProductInfo.OpCount));
            }
            if (orderProductInfo.OpPriceX != null)
            {
                sql += " and opPriceX=@OPPRICEX";
                paraList.Add(new SqlParameter("@OPPRICEX", orderProductInfo.OpPriceX));
            }
            if (orderProductInfo.OpName != null)
            {
                sql += " and opName=@OPNAME";
                paraList.Add(new SqlParameter("@OPNAME", orderProductInfo.OpName));
            }
            if (orderProductInfo.OpNumber != null)
            {
                sql += " and opNumber=@OPNUMBER";
                paraList.Add(new SqlParameter("@OPNUMBER", orderProductInfo.OpNumber));
            }
            if (orderProductInfo.OpSuppliter != null)
            {
                sql += " and opSuppliter=@OPSUPPLITER";
                paraList.Add(new SqlParameter("@OPSUPPLITER", orderProductInfo.OpSuppliter));
            }
            if (orderProductInfo.OpRemark != null)
            {
                sql += " and opRemark=@OPREMARK";
                paraList.Add(new SqlParameter("@OPREMARK", orderProductInfo.OpRemark));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(OrderProductInfo orderProductInfo, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            fields += "update_date=getdate(),";
            if (orderProductInfo.OpImageID != null)
            {
                fields += "opImageID=@UpdateOPIMAGEID,";
                paraList.Add(new SqlParameter("@UpdateOPIMAGEID", orderProductInfo.OpImageID));
            }
            if (orderProductInfo.OID != null)
            {
                fields += "oID=@UpdateOID,";
                paraList.Add(new SqlParameter("@UpdateOID", orderProductInfo.OID));
            }
            if (orderProductInfo.PID != null)
            {
                fields += "pID=@UpdatePID,";
                paraList.Add(new SqlParameter("@UpdatePID", orderProductInfo.PID));
            }
            if (orderProductInfo.CID != null)
            {
                fields += "cID=@UpdateCID,";
                paraList.Add(new SqlParameter("@UpdateCID", orderProductInfo.CID));
            }
            if (orderProductInfo.ONumber != null)
            {
                fields += "oNumber=@UpdateONUMBER,";
                paraList.Add(new SqlParameter("@UpdateONUMBER", orderProductInfo.ONumber));
            }
            if (orderProductInfo.OpPrice != null)
            {
                fields += "opPrice=@UpdateOPPRICE,";
                paraList.Add(new SqlParameter("@UpdateOPPRICE", orderProductInfo.OpPrice));
            }
            if (orderProductInfo.OpWeigth != null)
            {
                fields += "opWeigth=@UpdateOPWEIGTH,";
                paraList.Add(new SqlParameter("@UpdateOPWEIGTH", orderProductInfo.OpWeigth));
            }
            if (orderProductInfo.OpCount != null)
            {
                fields += "opCount=@UpdateOPCOUNT,";
                paraList.Add(new SqlParameter("@UpdateOPCOUNT", orderProductInfo.OpCount));
            }
            if (orderProductInfo.OpPriceX != null)
            {
                fields += "opPriceX=@UpdateOPPRICEX,";
                paraList.Add(new SqlParameter("@UpdateOPPRICEX", orderProductInfo.OpPriceX));
            }
            if (orderProductInfo.OpName != null)
            {
                fields += "opName=@UpdateOPNAME,";
                paraList.Add(new SqlParameter("@UpdateOPNAME", orderProductInfo.OpName));
            }
            if (orderProductInfo.OpNumber != null)
            {
                fields += "opNumber=@UpdateOPNUMBER,";
                paraList.Add(new SqlParameter("@UpdateOPNUMBER", orderProductInfo.OpNumber));
            }
            if (orderProductInfo.OpSuppliter != null)
            {
                fields += "opSuppliter=@UpdateOPSUPPLITER,";
                paraList.Add(new SqlParameter("@UpdateOPSUPPLITER", orderProductInfo.OpSuppliter));
            }
            if (orderProductInfo.OpRemark != null)
            {
                fields += "opRemark=@UpdateOPREMARK,";
                paraList.Add(new SqlParameter("@UpdateOPREMARK", orderProductInfo.OpRemark));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
        #endregion

        #region ExtensionMethod

        #endregion
    }
}
