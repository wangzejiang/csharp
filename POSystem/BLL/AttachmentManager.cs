using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSystem.Model;
using POSystem.DAL;

namespace POSystem.BLL
{
    /// <summary>
    /// Attachment管理类
    /// </summary>
    public class AttachmentManager
    {
        public static AttachmentService service = new AttachmentService();

        #region BasicMethod
		/// <summary>
        /// 增加Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表对象</param>
        /// <returns>受影响行数</returns>
        public static int AddAttachment(Attachment attachment)
        {
            return service.AddAttachment(attachment);
        }

        /// <summary>
        /// 删除Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表对象</param>
        /// <returns>受影响行数</returns>
        public static int DeleteAttachment(Attachment attachment = null)
        {
            return service.DeleteAttachment(attachment);
        }

        /// <summary>
        /// 更新Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表更新对象</param>
        /// <param name="oldAttachment">attachment表查询对象</param>
        /// <returns>受影响行数</returns>
        public static int UpdateAttachment(Attachment attachment, Attachment oldAttachment = null)
        {
            return service.UpdateAttachment(attachment,oldAttachment);
        }

        /// <summary>
        /// 查询Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表查询对象</param>
        /// <returns>IList对象集合</returns>
        public static IList<Attachment> GetAttachmentAll(Attachment attachment = null)
        {
            return service.GetAttachment(attachment);
        }

        /// <summary>
        /// 查询Attachment表信息
        /// </summary>
        /// <param name="attachment">attachment表查询对象</param>
        /// <returns>Attachment表对象</returns>
        public static Attachment GetAttachment(Attachment attachment)
        {
            return service.GetAttachment(attachment).Count > 0 ? service.GetAttachment(attachment)[0] : null;
        }

        /// <summary>
        /// 查询Attachment表信息是否存在
        /// </summary>
        /// <param name="attachment">attachment表查询对象</param>
        /// <returns>bool是否存在</returns>
        public static bool GetAttachmentBool(Attachment attachment)
        {
            return service.GetAttachment(attachment).Count > 0 ? true : false;
        }
	    #endregion

		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
