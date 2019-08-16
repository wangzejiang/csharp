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
    public class ProductInfoService
    {
        #region BasicMethod
        /// <summary>
        /// 增加ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int AddProductInfo(ProductInfo productInfo)
        {
            string sql = "insert into [ProductInfo](pImageID,pPrice,pPriceX,pWeigth,pName,pNumber,pSuppliter,pRemark) values(@PIMAGEID,@PPRICE,@PPRICEX,@PWEIGTH,@PNAME,@PNUMBER,@PSUPPLITER,@PREMARK)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@PIMAGEID",productInfo.PImageID == null ? Convert.DBNull : productInfo.PImageID),
                new SqlParameter("@PPRICE",productInfo.PPrice == null ? Convert.DBNull : productInfo.PPrice),
                new SqlParameter("@PPRICEX",productInfo.PPriceX == null ? Convert.DBNull : productInfo.PPriceX),
                new SqlParameter("@PWEIGTH",productInfo.PWeigth == null ? Convert.DBNull : productInfo.PWeigth),
                new SqlParameter("@PNAME",productInfo.PName == null ? Convert.DBNull : productInfo.PName),
                new SqlParameter("@PNUMBER",productInfo.PNumber == null ? Convert.DBNull : productInfo.PNumber),
                new SqlParameter("@PSUPPLITER",productInfo.PSuppliter == null ? Convert.DBNull : productInfo.PSuppliter),
                new SqlParameter("@PREMARK",productInfo.PRemark == null ? Convert.DBNull : productInfo.PRemark)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteProductInfo(ProductInfo productInfo)
        {
            string sql = "delete from [ProductInfo] where 1=1";
            List<SqlParameter> paraList = GetCondition(productInfo, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表更新对象</param>
        /// <param name="oldProductInfo">productInfo表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateProductInfo(ProductInfo productInfo, ProductInfo oldProductInfo)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(productInfo, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldProductInfo, ref conditions);
            string sql = "update [ProductInfo] set " + fields +
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }
        /// <summary>
        /// 查询ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<ProductInfo> GetProductInfo2(ProductInfo productInfo)
        {
            string sql = "select top 100 * from [Products] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (productInfo != null)
            {
                paraList = GetCondition(productInfo, ref sql);
            }
            sql += " order by update_date desc";
            IList<ProductInfo> productInfoList = new List<ProductInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                ProductInfo obj = new ProductInfo();
                obj.PImageID = Convert.IsDBNull(reader["pImageID"]) ? null : (Object)reader["pImageID"];
                obj.PID = Convert.IsDBNull(reader["pID"]) ? null : (int?)reader["pID"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.PPrice = Convert.IsDBNull(reader["pPrice"]) ? null : (decimal?)reader["pPrice"];
                obj.PPriceX = Convert.IsDBNull(reader["pPriceX"]) ? null : (decimal?)reader["pPriceX"];
                obj.PWeigth = Convert.IsDBNull(reader["pWeigth"]) ? null : (decimal?)reader["pWeigth"];
                obj.PName = Convert.IsDBNull(reader["pName"]) ? null : (string)reader["pName"];
                obj.PNumber = Convert.IsDBNull(reader["pNumber"]) ? null : (string)reader["pNumber"];
                obj.PSuppliter = Convert.IsDBNull(reader["pSuppliter"]) ? null : (string)reader["pSuppliter"];
                obj.PRemark = Convert.IsDBNull(reader["pRemark"]) ? null : (string)reader["pRemark"];
                obj.PImageBytes = Convert.IsDBNull(reader["Content"]) ? null : (byte[])reader["Content"];
                productInfoList.Add(obj);
            }
            reader.Close();
            return productInfoList;
        }

        /// <summary>
        /// 查询ProductInfo表信息
        /// </summary>
        /// <param name="productInfo">productInfo表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<ProductInfo> GetProductInfo(ProductInfo productInfo)
        {
            string sql = "select top 100 * from [ProductInfo] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (productInfo != null)
            {
                paraList = GetCondition(productInfo, ref sql);
            }

            IList<ProductInfo> productInfoList = new List<ProductInfo>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                ProductInfo obj = new ProductInfo();
                obj.PImageID = Convert.IsDBNull(reader["pImageID"]) ? null : (Object)reader["pImageID"];
                obj.PID = Convert.IsDBNull(reader["pID"]) ? null : (int?)reader["pID"];
                obj.UpdateDate = Convert.IsDBNull(reader["update_date"]) ? null : (DateTime?)reader["update_date"];
                obj.CreateDate = Convert.IsDBNull(reader["create_date"]) ? null : (DateTime?)reader["create_date"];
                obj.PPrice = Convert.IsDBNull(reader["pPrice"]) ? null : (decimal?)reader["pPrice"];
                obj.PPriceX = Convert.IsDBNull(reader["pPriceX"]) ? null : (decimal?)reader["pPriceX"];
                obj.PWeigth = Convert.IsDBNull(reader["pWeigth"]) ? null : (decimal?)reader["pWeigth"];
                obj.PName = Convert.IsDBNull(reader["pName"]) ? null : (string)reader["pName"];
                obj.PNumber = Convert.IsDBNull(reader["pNumber"]) ? null : (string)reader["pNumber"];
                obj.PSuppliter = Convert.IsDBNull(reader["pSuppliter"]) ? null : (string)reader["pSuppliter"];
                obj.PRemark = Convert.IsDBNull(reader["pRemark"]) ? null : (string)reader["pRemark"];
                productInfoList.Add(obj);
            }
            reader.Close();
            return productInfoList;
        }

        private static List<SqlParameter> GetCondition(ProductInfo productInfo, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (productInfo.PImageID != null)
            {
                sql += " and pImageID=@PIMAGEID";
                paraList.Add(new SqlParameter("@PIMAGEID", productInfo.PImageID));
            }
            if (productInfo.PID != null)
            {
                sql += " and pID=@PID";
                paraList.Add(new SqlParameter("@PID", productInfo.PID));
            }
            if (productInfo.UpdateDate != null)
            {
                sql += " and update_date=@UPDATEDATE";
                paraList.Add(new SqlParameter("@UPDATEDATE", productInfo.UpdateDate));
            }
            if (productInfo.CreateDate != null)
            {
                sql += " and create_date=@CREATEDATE";
                paraList.Add(new SqlParameter("@CREATEDATE", productInfo.CreateDate));
            }
            if (productInfo.PPrice != null)
            {
                sql += " and pPrice=@PPRICE";
                paraList.Add(new SqlParameter("@PPRICE", productInfo.PPrice));
            }
            if (productInfo.PPriceX != null)
            {
                sql += " and pPriceX=@PPRICEX";
                paraList.Add(new SqlParameter("@PPRICEX", productInfo.PPriceX));
            }
            if (productInfo.PWeigth != null)
            {
                sql += " and pWeigth=@PWEIGTH";
                paraList.Add(new SqlParameter("@PWEIGTH", productInfo.PWeigth));
            }
            if (productInfo.PName != null)
            {
                sql += " and pName like @PNAME";
                paraList.Add(new SqlParameter("@PNAME", "%" + productInfo.PName + "%"));
            }
            if (productInfo.PNumber != null)
            {
                sql += " and pNumber like @PNUMBER";
                paraList.Add(new SqlParameter("@PNUMBER", "%" + productInfo.PNumber + "%"));
            }
            if (productInfo.PSuppliter != null)
            {
                sql += " and pSuppliter like @PSUPPLITER";
                paraList.Add(new SqlParameter("@PSUPPLITER", "%" + productInfo.PSuppliter + "%"));
            }
            if (productInfo.PRemark != null)
            {
                sql += " and pRemark=@PREMARK";
                paraList.Add(new SqlParameter("@PREMARK", productInfo.PRemark));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(ProductInfo productInfo, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            fields += "update_date=getdate(),";
            if (productInfo.PImageID != null)
            {
                fields += "pImageID=@UpdatePIMAGEID,";
                paraList.Add(new SqlParameter("@UpdatePIMAGEID", productInfo.PImageID));
            }
            if (productInfo.PPrice != null)
            {
                fields += "pPrice=@UpdatePPRICE,";
                paraList.Add(new SqlParameter("@UpdatePPRICE", productInfo.PPrice));
            }
            if (productInfo.PPriceX != null)
            {
                fields += "pPriceX=@UpdatePPRICEX,";
                paraList.Add(new SqlParameter("@UpdatePPRICEX", productInfo.PPriceX));
            }
            if (productInfo.PWeigth != null)
            {
                fields += "pWeigth=@UpdatePWEIGTH,";
                paraList.Add(new SqlParameter("@UpdatePWEIGTH", productInfo.PWeigth));
            }
            if (productInfo.PName != null)
            {
                fields += "pName=@UpdatePNAME,";
                paraList.Add(new SqlParameter("@UpdatePNAME", productInfo.PName));
            }
            if (productInfo.PNumber != null)
            {
                fields += "pNumber=@UpdatePNUMBER,";
                paraList.Add(new SqlParameter("@UpdatePNUMBER", productInfo.PNumber));
            }
            if (productInfo.PSuppliter != null)
            {
                fields += "pSuppliter=@UpdatePSUPPLITER,";
                paraList.Add(new SqlParameter("@UpdatePSUPPLITER", productInfo.PSuppliter));
            }
            if (productInfo.PRemark != null)
            {
                fields += "pRemark=@UpdatePREMARK,";
                paraList.Add(new SqlParameter("@UpdatePREMARK", productInfo.PRemark));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
        #endregion

        #region ExtensionMethod

        #endregion
    }
}
