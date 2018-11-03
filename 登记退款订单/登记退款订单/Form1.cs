using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
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

namespace 登记退款订单
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private static ChromiumWebBrowser wb = null;
        private static ChromiumWebBrowser wb1 = null;

        private void InitializeChromium()
        {
            var settings = new CefSettings()
            {
                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN",
                MultiThreadedMessageLoop = true,
                CachePath = @"test\cache"
            };
            Cef.Initialize(settings);
            wb = new ChromiumWebBrowser(listurl);
            wb = new ChromiumWebBrowser("about:bank");
            tabPage1.Controls.Add(wb);
            tabPage3.Controls.Add(wb1);
            wb.Dock = DockStyle.Fill;
        }

        private string listurl = "https://refund2.tmall.com/dispute/sellerDisputeList.htm?type=1";

        private void button1_Click(object sender1, EventArgs e1)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            // 宝儿玩具专营店:小江
            HtmlAgilityPack.HtmlDocument hd = getText(wb);
            HtmlNode divs = hd.DocumentNode.SelectSingleNode("//*[@id='bottomContainer_1']");
            if (divs == null) return;
            foreach (HtmlNode div in divs.ChildNodes)
            {
                if (div.Id.StartsWith("sellerGridContainer_"))
                {
                    string iid = div.SelectSingleNode("div/ul/li[2]/div/div/em").InnerText.Trim();
                    int count = dt.Select(string.Format("iid={0}", iid)).Length;
                    if (count == 0)
                    {
                        DataRow dr = dt.NewRow();
                        string id = div.SelectSingleNode("div/ul/li[3]/div/div/em").InnerText.Trim();
                        dr["id"] = id;
                        dr["iid"] = iid;
                        dr["href"] = div.SelectSingleNode("div/div[8]/a").GetAttributeValue("href", null);
                        HtmlNode remarkNode = div.SelectSingleNode(string.Format("//*[@id='sellerGirdRemarkContainer_{0}@2']/span/div/span", iid));
                        dr["remark"] = remarkNode != null ? remarkNode.InnerText.Trim() : "";
                        dt.Rows.Add(dr);
                    }
                }
            }
        }
        public void WaitFor(int ms)
        {
            DateTime time = DateTime.Now;
            while (true)
            {
                Application.DoEvents();
                TimeSpan span = DateTime.Now - time;
                if (span.TotalMilliseconds > ms) break;
            }
        }
        private HtmlAgilityPack.HtmlDocument getText(ChromiumWebBrowser wb)
        {
            WaitFor(2000);
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            try
            {
                Task<string> task = wb.GetSourceAsync();
                // task.Wait();
                var text = task.Result;

                hd.LoadHtml(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return hd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            input(@"js1.txt");
        }

        private void input(string path)
        {
            wb.ExecuteScriptAsync(File.ReadAllText(path));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wb.Load(listurl);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("iid", typeof(string)));
            dt.Columns.Add(new DataColumn("id", typeof(string)));
            dt.Columns.Add(new DataColumn("href", typeof(string)));
            dt.Columns.Add(new DataColumn("remark", typeof(string)));
            dt.Columns.Add(new DataColumn("express", typeof(string)));
            dt.Columns.Add(new DataColumn("number", typeof(string)));
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender1, EventArgs e1)
        {
            StringVisitor sv = new StringVisitor();
            if (wb == null) return;
            wb.Load(listurl);
            input(@"js3.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            input(@"js.txt");
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            input(@"js2.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                string href = string.Format("https:{0}", row["href"].ToString());
                wb1.Load(href);
                HtmlAgilityPack.HtmlDocument hd = getText(wb1);
                HtmlNode div = hd.DocumentNode.SelectSingleNode("//*[@id='contentContainer_1']/div[3]/div/p");
                if (div != null)
                {
                    Console.WriteLine(div.InnerText);
                    row["express"] = div.InnerText.Substring(div.InnerText.IndexOf("：") + 1, div.InnerText.IndexOf("（") - div.InnerText.IndexOf("：") - 1);
                    row["number"] = div.InnerText.Substring(div.InnerText.IndexOf("（") + 1, div.InnerText.IndexOf(")") - div.InnerText.IndexOf("（") - 1);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
