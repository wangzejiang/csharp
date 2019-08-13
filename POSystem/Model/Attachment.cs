using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSystem.Model
{
    /// <summary>
    /// Attachment实体
    /// </summary>
    [Serializable]
    public class Attachment
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public Attachment(){}

        /// <summary>
        /// 带参构造
        /// </summary>
        public Attachment(Object ID, Int64? Length, Object Content)
        {
            this.ID = ID;
            this.Length = Length;
            this.Content = Content;
        }

        /// <summary>
        /// 
        /// </summary>
        public Object ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64? Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Object Content { get; set; }
    }
}
