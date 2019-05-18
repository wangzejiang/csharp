using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anylsycm
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
            textBox1.Text = Utils.readTopWords();
            webBrowser1 = new MyWebBrowser();
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(3, 3);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(886, 373);
            webBrowser1.TabIndex = 0;
            tabPage1.Controls.Add(webBrowser1);
            webBrowser1.Navigate("https://sycm.taobao.com");
            Text = webBrowser1.Version.Major.ToString();
            timer1.Interval = 2000;
            timer1.Start();
        }
        private void webBrowser1_DocumentCompleted(object sender, EventArgs e)//这个就是当网页载入完毕后要进行的操作
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            staticnum = 0;
            getKey();
        }

        private static int staticnum = 0;

        private void getKey()
        {
            string[] keys = textBox1.Text.Split(',');
            for (; staticnum < keys.Length; staticnum++)
            {
                DateTime now = DateTime.Now.AddHours(-8).AddDays(-1);
                string word = keys[staticnum];
                for (int i = 0; i < 30; i++)
                {
                    string datestr = now.AddDays(-i).ToString("yyyy-MM-dd");
                    string path = string.Format(Utils.getConfig(@"sycmGData/{0}_{1}.txt"), word, datestr);
                    if (File.Exists(path)) continue;

                    StringBuilder sb = new StringBuilder();
                    sb.Append("https://sycm.taobao.com/mc/mq/search_analyze?");
                    sb.AppendFormat("activeKey=overview&dateRange={0}%7C{0}&dateType=day&device=0&keyword={1}", datestr, word);
                    webBrowser1.Navigate(sb.ToString());
                    return;
                }
            }
            MessageBox.Show("over" + staticnum);
        }

        private void runjs()
        {
            HtmlElement script = webBrowser1.Document.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.SetAttribute("text", File.ReadAllText(Utils.getConfig(@"cc.js")));
            HtmlElement head = webBrowser1.Document.Body.AppendChild(script);
            webBrowser1.Document.InvokeScript("_func");
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private HtmlElement getElemet(string tag, string className)
        {
            HtmlElement el = null;
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName(tag);
            foreach (HtmlElement element in elements)
            {
                if (className.ToUpper().Equals(element.GetAttribute("className").ToUpper()))
                {
                    el = element;
                    break;
                }
            }
            return el;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            HtmlElement el;
            string date, key, num = null;

            // 获取数字
            el = getElemet("div", "oui-index-cell-indexValue oui-num");
            if (el == null) return;
            num = el.InnerHtml;
            // 获取日期
            el = getElemet("div", "oui-date-picker-current-date");
            if (el == null) return;
            date = el.InnerHtml;
            // 获取单词
            el = getElemet("span", "item-keyword");
            if (el == null) return;
            key = el.InnerHtml;
            num = num.Replace(",", "");
            num = num.Remove(num.IndexOf("<!-"), num.IndexOf("->") + 2 - num.IndexOf("<!-"));
            num = num.Remove(num.IndexOf("<!-"), num.IndexOf("->") + 2 - num.IndexOf("<!-"));
            date = date.Replace("统计时间 ", "");
            date = date.Remove(date.IndexOf("<!-"), date.IndexOf("->") + 2 - date.IndexOf("<!-"));
            date = date.Remove(date.IndexOf("<!-"), date.IndexOf("->") + 2 - date.IndexOf("<!-"));
            date = date.Remove(date.IndexOf("<!-"), date.IndexOf("->") + 2 - date.IndexOf("<!-"));
            date = date.Remove(date.IndexOf("<!-"), date.IndexOf("->") + 2 - date.IndexOf("<!-"));
            Console.WriteLine("{0},{1},{2}", key, num, date);
            string path = string.Format(Utils.getConfig(@"sycmGData/{0}_{1}.txt"), key, date);
            int day = DateTime.Now.AddHours(-8).AddDays(-1).DayOfYear - Convert.ToDateTime(date).DayOfYear;
            if (File.Exists(path) == false && day < 30)
            {
                var os = File.CreateText(path);
                os.Write(num);
                os.Close();
                runjs();
            }
            else
            {
                staticnum++;
                if (textBox1.Text.Split(',').Length > staticnum)
                {
                    getKey();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://ie.icoa.cn/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HtmlElement script = webBrowser1.Document.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.SetAttribute("text", File.ReadAllText(Utils.getConfig(@"login.js")));
            HtmlElement head = webBrowser1.Document.Body.AppendChild(script);
            webBrowser1.Document.InvokeScript("_login");
        }
    }
}
