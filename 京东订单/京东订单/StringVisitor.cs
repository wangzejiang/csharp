using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 京东订单
{
    public class StringVisitor : IStringVisitor
    {
        private string item;
        private string time;
        private string value;
        private string currPage;
        private bool read = false;

        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string CurrPage
        {
            get
            {
                return currPage;
            }

            set
            {
                currPage = value;
            }
        }

        public bool Read
        {
            get
            {
                return read;
            }

            set
            {
                read = value;
            }
        }

        public void Dispose()
        {
        }

        public void Visit(string str)
        {
            value = str;
        }
    }
}
