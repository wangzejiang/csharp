using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MyWebBrowser webBrowser1;
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1 = new MyWebBrowser();
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(3, 3);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(886, 373);
            webBrowser1.TabIndex = 0;
            tabPage1.Controls.Add(this.webBrowser1);
            webBrowser1.Navigate("https://sycm.taobao.com");

            timer1.Interval = 1000;
            timer1.Start();
        }
        private void webBrowser1_DocumentCompleted(object sender, EventArgs e)//这个就是当网页载入完毕后要进行的操作
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("https://sycm.taobao.com/mc/mq/search_analyze?");
            sb.AppendFormat("activeKey=overview&dateRange={0}%7C{0}&dateType=day&device=0&keyword={1}", "2019-05-07", "98k");
            webBrowser1.Navigate(sb.ToString());
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HtmlElement el = null;
            // Console.WriteLine(webBrowser1.DocumentText);
            //webBrowser1.DocumentText;
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement element in elements)
            {
                if ("oui-index-cell-indexValue oui-num".ToUpper().Equals(element.GetAttribute("className").ToUpper()))
                {
                    el = element;
                    break;
                }
            }
            if (el == null) return;
            Console.WriteLine(el.InnerHtml);
            foreach (HtmlElement element in elements)
            {
                if ("oui-date-picker-current-date".ToUpper().Equals(element.GetAttribute("className").ToUpper()))
                {
                    el = element;
                    break;
                }
            }
            if (el == null) return;
            Console.WriteLine(el.InnerHtml);
            elements = webBrowser1.Document.GetElementsByTagName("span");
            foreach (HtmlElement element in elements)
            {
                if ("item-keyword".ToUpper().Equals(element.GetAttribute("className").ToUpper()))
                {
                    el = element;
                    break;
                }
            }
            if (el == null) return;
            Console.WriteLine(el.InnerHtml);
        }
    }
}
