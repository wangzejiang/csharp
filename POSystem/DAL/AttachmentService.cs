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
    public class AttachmentService
    {
        #region BasicMethod
		/// <summary>
        /// 增加Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表对象</param>
        /// <returns>受影响行数</returns>
        public int AddAttachment(Attachment attachment)
        {
            string sql = "insert into [Attachment](ID,length,Content) values(@ID,@LENGTH,@CONTENT)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@ID",attachment.ID == null ? Convert.DBNull : attachment.ID),
                new SqlParameter("@LENGTH",attachment.Length == null ? Convert.DBNull : attachment.Length),
                new SqlParameter("@CONTENT",attachment.Content == null ? Convert.DBNull : attachment.Content)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 删除Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表对象</param>
        /// <returns>受影响行数</returns>
        public int DeleteAttachment(Attachment attachment)
        {
            string sql = "delete from [Attachment] where 1=1";
            List<SqlParameter> paraList = GetCondition(attachment, ref sql);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
        }

        /// <summary>
        /// 更新Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表更新对象</param>
        /// <param name="oldAttachment">attachment表查询对象</param>
        /// <returns>受影响行数</returns>
        public int UpdateAttachment(Attachment attachment, Attachment oldAttachment)
        {
            string fields = "";
            string conditions = "";
            List<SqlParameter> fieldsParameter = GetUpdateFields(attachment, ref fields);
            List<SqlParameter> conditionParameter = GetCondition(oldAttachment, ref conditions);
            string sql = "update [Attachment] set " + fields + 
                         " where 1=1" + conditions;
            fieldsParameter.AddRange(conditionParameter);
            SqlParameter[] paras = fieldsParameter.ToArray();
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paras);
        }

        /// <summary>
        /// 查询Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表查询对象</param>
        /// <returns>IList对象集合</returns>
        public IList<Attachment> GetAttachment(Attachment attachment)
        {
            string sql = "select * from [Attachment] where 1=1";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if(attachment!=null)
            {
                paraList = GetCondition(attachment, ref sql);
            }

            IList<Attachment> attachmentList = new List<Attachment>();
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, paraList.ToArray());
            while (reader.Read())
            {
                Attachment obj = new Attachment();
                obj.ID = Convert.IsDBNull(reader["ID"]) ? null : (Object)reader["ID"];
                obj.Length = Convert.IsDBNull(reader["length"]) ? null : (Int64?)reader["length"];
                obj.Content = Convert.IsDBNull(reader["Content"]) ? null : (Object)reader["Content"];
                attachmentList.Add(obj);
            }
            reader.Close();
            return attachmentList;
        }

        private static List<SqlParameter> GetCondition(Attachment attachment, ref string sql)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (attachment.ID != null)
            {
                sql += " and ID=@ID";
                paraList.Add(new SqlParameter("@ID", attachment.ID));
            }
            if (attachment.Length != null)
            {
                sql += " and length=@LENGTH";
                paraList.Add(new SqlParameter("@LENGTH", attachment.Length));
            }
            if (attachment.Content != null)
            {
                sql += " and Content=@CONTENT";
                paraList.Add(new SqlParameter("@CONTENT", attachment.Content));
            }
            return paraList;
        }

        private static List<SqlParameter> GetUpdateFields(Attachment attachment, ref string fields)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            fields = "";
            if (attachment.ID != null)
            {
                fields += "ID=@UpdateID,";
                paraList.Add(new SqlParameter("@UpdateID", attachment.ID));
            }
            if (attachment.Length != null)
            {
                fields += "length=@UpdateLENGTH,";
                paraList.Add(new SqlParameter("@UpdateLENGTH", attachment.Length));
            }
            if (attachment.Content != null)
            {
                fields += "Content=@UpdateCONTENT,";
                paraList.Add(new SqlParameter("@UpdateCONTENT", attachment.Content));
            }
            fields = fields.Substring(0, fields.Length - 1);
            return paraList;
        }
	    #endregion

        #region ExtensionMethod
		 
	    #endregion
    }
}
