using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// UserInfo实体
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public UserInfo(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public UserInfo(int? UID, DateTime? CreateDate, DateTime? UpdateDate, string UName, string UPassword, string Attr1, string Attr2, string Attr3, string Attr4, string Attr5, string Attr6)
        {
            this.UID = UID;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.UName = UName;
            this.UPassword = UPassword;
            this.Attr1 = Attr1;
            this.Attr2 = Attr2;
            this.Attr3 = Attr3;
            this.Attr4 = Attr4;
            this.Attr5 = Attr5;
            this.Attr6 = Attr6;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UPassword { get; set; }
        public string Attr1 { get; set; }
        public string Attr2 { get; set; }
        public string Attr3 { get; set; }
        public string Attr4 { get; set; }
        public string Attr5 { get; set; }
        public string Attr6 { get; set; }
    }
}
