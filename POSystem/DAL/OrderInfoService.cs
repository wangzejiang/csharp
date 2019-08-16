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
            //string sql = "insert into [OrderInfo](oStatus,oDate,create_date,update_date,oWeigth,oPrice,oPriceX,oPriceZ,uName,oNumber,cName,cPhone,cAddress,oRemark,oRemark2) values(@OSTATUS,@ODATE,@CREATEDATE,@UPDATEDATE,@OWEIGTH,@OPRICE,@OPRICEX,@OPRICEZ,@UNAME,@ONUMBER,@CNAME,@CPHONE,@CADDRESS,@OREMARK,@OREMARK2)";
            string sql = "insert into [OrderInfo](oStatus,oDate,oWeigth,oPrice,oPriceX,oPriceOK,oPriceZ,uName,oNumber,cName,cPhone,cAddress,oRemark,oRemark2) values(@OSTATUS,@ODATE,@OWEIGTH,@OPRICE,@OPRICEX,@OPRICEOK,@OPRICEZ,@UNAME,@ONUMBER,@CNAME,@CPHONE,@CADDRESS,@OREMARK,@OREMARK2)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@OSTATUS",orderInfo.OStatus == null ? Convert.DBNull : orderInfo.OStatus),
                new SqlParameter("@ODATE",orderInfo.ODate == null ? Convert.DBNull : orderInfo.ODate),
                //new SqlParameter("@CREATEDATE",orderInfo.CreateDate == null ? Convert.DBNull : orderInfo.CreateDate),
               // new SqlParameter("@UPDATEDATE",orderInfo.UpdateDate == null ? Convert.DBNull : orderInfo.UpdateDate),
                new SqlParameter("@OWEIGTH",orderInfo.OWeigth == null ? Convert.DBNull : orderInfo.OWeigth),
                new SqlParameter("@OPRICE",orderInfo.OPrice == null ? Convert.DBNull : orderInfo.OPrice),
                new SqlParameter("@OPRICEX",orderInfo.OPriceX == null ? Convert.DBNull : orderInfo.OPriceX),
                new SqlParameter("@OPRICEOK",orderInfo.OPriceOK == null ? Convert.DBNull : orderInfo.OPriceOK),
                new SqlParameter("@OPRICEZ",orderInfo.OPriceZ == null ? Convert.DBNull : orderInfo.OPriceZ),
                new SqlParameter("@UNAME",orderInfo.UName == null ? Convert.DBNull : orderInfo.UName),
                new SqlParameter("@ONUMBER",orderInfo.ONumber == null ? Convert.DBNull : orderInfo.ONumber),
                new SqlParameter("@CNAME",orderInfo.CName == null ? Convert.DBNull : orderInfo.CName),
                new SqlParameter("@CPHONE",orderInfo.CPhone == null ? Convert.DBNull : orderInfo.CPhone),
                new SqlParameter("@CADDRESS",orderInfo.CAddress == null ? Convert.DBNull : orderInfo.CAddress),
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
            string sql = "select top 100 * from [OrderInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (orderInfo != null)
            {
                paraList = GetCondition(orderInfo, ref sql);
            }
            sql += " order by update_date desc";
            IList<OrderInfo> orderInfoList = new List<OrderInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                OrderInfo obj = new OrderInfo();
                obj.OID = Convert.IsDBNull(reader["oID"]) ? null : (int?)reader["oID"];
                obj.OStatus = Convert.IsDBNull(reader["oStatus"]) ? null : (int?)reader["oStatus"];
                obj.ODate = Convert.IsDBNull(reader["oDate"]) ? null : (DateTime?)reader["oDate"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.OWeigth = Convert.IsDBNull(reader["oWeigth"]) ? null : (decimal?)reader["oWeigth"];
                obj.OPrice = Convert.IsDBNull(reader["oPrice"]) ? null : (decimal?)reader["oPrice"];
                obj.OPriceX = Convert.IsDBNull(reader["oPriceX"]) ? null : (decimal?)reader["oPriceX"];
                obj.OPriceOK = Convert.IsDBNull(reader["oPriceOK"]) ? null : (decimal?)reader["oPriceOK"];
                obj.OPriceZ = Convert.IsDBNull(reader["oPriceZ"]) ? null : (decimal?)reader["oPriceZ"];
                obj.UName = Convert.IsDBNull(reader["uName"]) ? null : (string)reader["uName"];
                obj.ONumber = Convert.IsDBNull(reader["oNumber"]) ? null : (string)reader["oNumber"];
                obj.CName = Convert.IsDBNull(reader["cName"]) ? null : (string)reader["cName"];
                obj.CPhone = Convert.IsDBNull(reader["cPhone"]) ? null : (string)reader["cPhone"];
                obj.CAddress = Convert.IsDBNull(reader["cAddress"]) ? null : (string)reader["cAddress"];
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
            if (orderInfo.OWeigth != null)
            {
                sql += " and oWeigth=@OWEIGTH";
                paraList.Add(new SqlParameter("@OWEIGTH", orderInfo.OWeigth));
            }
            if (orderInfo.OPrice != null)
            {
                sql += " and oPrice=@OPRICE";
                paraList.Add(new SqlParameter("@OPRICE", orderInfo.OPrice));
            }
            if (orderInfo.OPriceX != null)
            {
                sql += " and oPriceX=@OPRICEX";
                paraList.Add(new SqlParameter("@OPRICEX", orderInfo.OPriceX));
            }
            if (orderInfo.OPriceOK != null)
            {
                sql += " and oPriceOK=@OPRICEOK";
                paraList.Add(new SqlParameter("@OPRICEOK", orderInfo.OPriceOK));
            }
            if (orderInfo.OPriceZ != null)
            {
                sql += " and oPriceZ=@OPRICEZ";
                paraList.Add(new SqlParameter("@OPRICEZ", orderInfo.OPriceZ));
            }
            if (orderInfo.UName != null)
            {
                sql += " and uName=@UNAME";
                paraList.Add(new SqlParameter("@UNAME", orderInfo.UName));
            }
            if (orderInfo.ONumber != null)
            {
                sql += " and oNumber like @ONUMBER";
                paraList.Add(new SqlParameter("@ONUMBER", "%" + orderInfo.ONumber + "%"));
            }
            if (orderInfo.CName != null)
            {
                sql += " and cName like @CNAME";
                paraList.Add(new SqlParameter("@CNAME", "%" + orderInfo.CName + "%"));
            }
            if (orderInfo.CPhone != null)
            {
                sql += " and cPhone=@CPHONE";
                paraList.Add(new SqlParameter("@CPHONE", orderInfo.CPhone));
            }
            if (orderInfo.CAddress != null)
            {
                sql += " and cAddress=@CADDRESS";
                paraList.Add(new SqlParameter("@CADDRESS", orderInfo.CAddress));
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
            fields += "update_date=getDate(),";
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
            if (orderInfo.OWeigth != null)
            {
                fields += "oWeigth=@UpdateOWEIGTH,";
                paraList.Add(new SqlParameter("@UpdateOWEIGTH", orderInfo.OWeigth));
            }
            if (orderInfo.OPrice != null)
            {
                fields += "oPrice=@UpdateOPRICE,";
                paraList.Add(new SqlParameter("@UpdateOPRICE", orderInfo.OPrice));
            }
            if (orderInfo.OPriceX != null)
            {
                fields += "oPriceX=@UpdateOPRICEX,";
                paraList.Add(new SqlParameter("@UpdateOPRICEX", orderInfo.OPriceX));
            }
            if (orderInfo.OPriceOK != null)
            {
                fields += "oPriceOK=@UpdateOPRICEOK,";
                paraList.Add(new SqlParameter("@UpdateOPRICEOK", orderInfo.OPriceOK));
            }
            if (orderInfo.OPriceZ != null)
            {
                fields += "oPriceZ=@UpdateOPRICEZ,";
                paraList.Add(new SqlParameter("@UpdateOPRICEZ", orderInfo.OPriceZ));
            }
            if (orderInfo.UName != null)
            {
                fields += "uName=@UpdateUNAME,";
                paraList.Add(new SqlParameter("@UpdateUNAME", orderInfo.UName));
            }
            if (orderInfo.ONumber != null)
            {
                fields += "oNumber=@UpdateONUMBER,";
                paraList.Add(new SqlParameter("@UpdateONUMBER", orderInfo.ONumber));
            }
            if (orderInfo.CName != null)
            {
                fields += "cName=@UpdateCNAME,";
                paraList.Add(new SqlParameter("@UpdateCNAME", orderInfo.CName));
            }
            if (orderInfo.CPhone != null)
            {
                fields += "cPhone=@UpdateCPHONE,";
                paraList.Add(new SqlParameter("@UpdateCPHONE", orderInfo.CPhone));
            }
            if (orderInfo.CAddress != null)
            {
                fields += "cAddress=@UpdateCADDRESS,";
                paraList.Add(new SqlParameter("@UpdateCADDRESS", orderInfo.CAddress));
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
