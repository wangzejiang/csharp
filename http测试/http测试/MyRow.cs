using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace http测试
{
    public class MyRow
    {
        private string url;

        private string body;

        public MyRow(string url, string body)
        {
            this.url = url;
            this.body = body;
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }

            set
            {
                body = value;
            }
        }
    }
}
