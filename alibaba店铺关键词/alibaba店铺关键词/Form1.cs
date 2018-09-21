using CefSharp;
using CefSharp.WinForms;
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

namespace alibaba店铺关键词
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabPage1.Controls.Add(createChromiumWebBrowser());
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("num", typeof(int)));
            dt.Columns.Add(new DataColumn("page", typeof(int)));
            dt.Columns.Add(new DataColumn("title", typeof(string)));
            dt.Columns.Add(new DataColumn("href", typeof(string)));
            dt.Columns.Add(new DataColumn("keywords1", typeof(string)));
            dt.Columns.Add(new DataColumn("keywords2", typeof(string)));
            dt.Columns.Add(new DataColumn("keywords3", typeof(string)));
            dt.Columns.Add(new DataColumn("description", typeof(string)));
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private ChromiumWebBrowser createChromiumWebBrowser(string url = "about:blank")
        {
            ChromiumWebBrowser wb = new ChromiumWebBrowser(url);
            wb.Name = "ChromiumWebBrowser";
            return wb;
        }

        private ChromiumWebBrowser getChromiumWebBrowser(Control tab)
        {
            return (ChromiumWebBrowser)tab.Controls["ChromiumWebBrowser"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Clear();
            int size = getPageSize();
            Console.WriteLine(size);
            int num = 0;
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNodeCollection ulNodes = null;
            HtmlAgilityPack.HtmlNodeCollection liNodes = null;
            HtmlAgilityPack.HtmlNode titleNote = null;
            for (int i = 1; i <= size; i++)
            {
                string url = string.Format("https://{0}.en.alibaba.com/productlist-{1}.html", textBox1.Text,i);
                string text = toUrl(url);
                hd.LoadHtml(text);
                ulNodes = hd.DocumentNode.SelectNodes("//*[@id='products-container']/div/ul");
                foreach (var ul in ulNodes)
                {
                    liNodes = ul.SelectNodes("li");
                    foreach (var li in liNodes)
                    {
                        titleNote = li.SelectSingleNode("div/div[2]/a");
                        var dr = dt.NewRow();
                        dr["num"] = ++num;
                        dr["page"] = i;
                        dr["title"] = titleNote.InnerHtml.Replace("\t", "").Replace("\n", "").Trim();
                        string href = titleNote.GetAttributeValue("href", "");
                        dr["href"] = href;
                        string[] st = getKeysAndDesc(href);
                        dr["keywords1"] = st[0].Split(',')[0];
                        dr["keywords2"] = st[0].Split(',')[1];
                        dr["keywords3"] = st[0].Split(',')[2];
                        dr["description"] = st[1];
                        dt.Rows.Add(dr);
                    }
                }
            }
        }
        private string[] getKeysAndDesc(string href)
        {
            string url = string.Format("https://{0}.en.alibaba.com{1}",textBox1.Text,href);
            string text = toUrl(url);
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNode keys =
                hd.DocumentNode.SelectSingleNode("/html/head/meta[2]");
            HtmlAgilityPack.HtmlNode desc =
                hd.DocumentNode.SelectSingleNode("/html/head/meta[3]");
            string keywords = keys.GetAttributeValue("content","");
            string description = desc.GetAttributeValue("content", "");
            return new string[] { keywords, description };
        }

        private string toUrl(string url)
        {
            Thread t = new Thread(o => Thread.Sleep(3000));
            t.Start(this);
            while (t.IsAlive)
            {
                Application.DoEvents();
            }
            StringVisitor sv = new StringVisitor();
            var wb = getChromiumWebBrowser(tabPage1);
            wb.Load(url);
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender1, e1) =>
            {
                if (!e1.IsLoading)
                {
                    e1.Browser.MainFrame.GetSource(sv);
                    wb.LoadingStateChanged -= handler;
                }
            };
            wb.LoadingStateChanged += handler;
            while (sv.Value == null || "".Equals(sv.Value))
            {
                Application.DoEvents();
            }
            return sv.Value;
        }
        
        private int getPageSize()
        {
            string url = string.Format("https://{0}.en.alibaba.com/productlist.html",textBox1.Text);
            string text = toUrl(url);
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNode node =
                hd.DocumentNode.SelectSingleNode("//*[@id='site_content']/div[1]/div/div[1]/script[1]");
            if (node == null)
            {
                return 0;
            }
            string str = node.InnerText.Replace("\n","").Replace("\t","").Replace(" ","");
            int tmp1 = "totalPages:".Length;
            int tmp2 = str.IndexOf("totalPages:");
            string num1 = str.Substring(tmp1+tmp2, str.Length-tmp2-tmp1-1);
            return int.Parse(num1);
        }
    }
}
