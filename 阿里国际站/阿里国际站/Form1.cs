using alibaba标题分析;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 阿里国际站
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dicZH = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        string[] strArr = File.ReadAllLines(@"英汉词典.txt", Encoding.Default);

        public Form1()
        {
            InitializeComponent();
            tabPage1.Controls.Add(createChromiumWebBrowser());
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("编号", typeof(int)));
            dt.Columns.Add(new DataColumn("标题", typeof(string)));
            dt.Columns.Add(new DataColumn("车位", typeof(string)));
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("单词", typeof(string)));
            dt2.Columns.Add(new DataColumn("中文", typeof(string)));
            dt2.Columns.Add(new DataColumn("数量", typeof(int)));
            dataGridView2.DataSource = dt2;

            for (int i = 0; i < strArr.Length; i++)
            {
                string[] strArr1 = strArr[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (dicZH.Keys.Contains(strArr1[0]) == false)
                {
                    dicZH.Add(strArr1[0], strArr1[1]);
                }
            }
        }

        private ChromiumWebBrowser createChromiumWebBrowser(string url = "about:blank")
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            ChromiumWebBrowser wb = new ChromiumWebBrowser(url);
            wb.LifeSpanHandler = new OpenPageSelf();
            wb.Name = "ChromiumWebBrowser";
            return wb;
        }

        private ChromiumWebBrowser getChromiumWebBrowser(Control tab)
        {
            return (ChromiumWebBrowser)tab.Controls["ChromiumWebBrowser"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private StringVisitor sv = new StringVisitor();
        private int i = 0;

        private string getWBValue()
        {
            while (sv.Value == null || "".Equals(sv.Value))
            {
                Application.DoEvents();
            }
            return sv.Value;
        }

        private void button1_Click(object sender1, EventArgs e1)
        {
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            string url = "www.alibaba.com";
            wb.Load(url);
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, e) =>
            {
                if (!e.IsLoading)
                {
                    e.Browser.MainFrame.GetSource(sv);
                    updateUrl(e.Browser.MainFrame.Url);
                    //wb.LoadingStateChanged -= handler;
                }
            };
            wb.LoadingStateChanged += handler;
        }

        #region
        private string getFy(string word)
        {
            var wb = getChromiumWebBrowser(tabPage1);
            string url = "http://dict.baidu.com/s?wd=" + word;
            wb.Load(url);
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, e) =>
            {
                if (!e.IsLoading)
                {
                    e.Browser.MainFrame.GetSource(sv);
                    wb.LoadingStateChanged -= handler;
                }
            };
            wb.LoadingStateChanged += handler;
            while (sv.Value == null || "".Equals(sv.Value))
            {
                Application.DoEvents();
            }
            string text = sv.Value;
            if ("<html><head></head><body></body></html>".Equals(text))
            {
                return "";
            }
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNode node =
                hd.DocumentNode.SelectSingleNode("//*[@id='fanyi-wrapper']/div/a");
            if (node == null)
            {
                return "";
            }
            Console.WriteLine(node.InnerText);
            return node.InnerText;
        }
        #endregion

        private void updateUrl(string url)
        {
            Action act = delegate () { this.textBox1.Text = url; };
            this.Invoke(act);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var xpaths = initXpaths();
            label1.Text = "";
            tabControl1.SelectedTab = tabPage2;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            string text = getWBValue();
            if ("<html><head></head><body></body></html>".Equals(text))
            {
                return;
            }
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNodeCollection nodes = null;
            HtmlAgilityPack.HtmlNode divNote = null;
            HtmlAgilityPack.HtmlNode slNote = null;
            int type = 0;
            for (int i = 1; i <= 5; i++)
            {
                type = i * 10;
                nodes = hd.DocumentNode.SelectNodes(xpaths[type]);
                if (nodes != null)
                {
                    break;
                }
            }
            if (nodes == null)
            {
                label1.Text = "没找到";
                return;
            }
            Console.WriteLine("分类--------------->"+type);
            nodes = hd.DocumentNode.SelectNodes(xpaths[type + 1]);
            foreach (var note in nodes)
            {
                i++;
                divNote = note.SelectSingleNode(xpaths[type + 2]);
                string tmp = xpaths[type + 3];
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    foreach (var t in tmp.Split('|'))
                    {
                        slNote = note.SelectSingleNode(t);
                        if (slNote != null)
                        {
                            break;
                        }
                    }
                }
                var dr = dt.NewRow();
                dr["编号"] = i;
                dr["标题"] = divNote != null ? replace(divNote.InnerHtml) : "";
                dr["车位"] = slNote != null;
                dt.Rows.Add(dr);
            }
            label1.Text = "抓取结束" + i;
        }

        public Dictionary<int, string> initXpaths()
        {
            Dictionary<int, string> xpaths = new Dictionary<int, string>();

            xpaths.Add(10, "/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/div/div[6]/div[1]/div[1]/div/div[1]/div[1]/div/div/div[1]/h2/a");
            xpaths.Add(11, "/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/div/div[6]/div[1]/div");
            xpaths.Add(12, "div/div[1]/div[1]/div/div/div[1]/h2/a");
            xpaths.Add(13, "div/div[2]/div[1]/div/div/span/text()");
            // 分类方格
            xpaths.Add(20, "/html/body/div[1]/div[2]/div[2]/div[3]/div[1]/div/div/div/div[1]/div/div/div[2]/h2/a");
            xpaths.Add(21, "/html/body/div[1]/div[2]/div[2]/div[3]/div[1]/div/div/div/div");
            xpaths.Add(22, "div/div/div[2]/h2/a");
            xpaths.Add(23, "div/div/div[2]/h2/a/div/div|div/div/div[2]/h2/a/i");
            // 分类列表
            xpaths.Add(30, "/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[1]/div[1]/div/div[1]/div[1]/div/div/div[1]/h2/a");
            xpaths.Add(31, "/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[1]/div");
            xpaths.Add(32, "div/div[1]/div[1]/div/div/div[1]/h2/a");
            xpaths.Add(33, "div/div[2]/div[1]/div/div/span");

            xpaths.Add(40, "/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[1]/div[1]/div/div[2]/div[1]/h2/a");
            xpaths.Add(41, "/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[1]/div");
            xpaths.Add(42, "div/div[2]/div[1]/h2/a");
            xpaths.Add(43, "");

            xpaths.Add(50, "//*h2[@class='title']");

            return xpaths;
        }

        private string replace(string str)
        {
            return str
                .Replace("<i class=\"ui2-icon ui2-icon-crown\" title=\"Top Sponsored Listing\"></i>", "")
                .Replace("<div class=\"ad-flag\">", "")
                .Replace("</div>","")
                .Replace("<div class=\"sl\">", "")
                .Replace("Ad\n","")
                .Replace("<strong>", "")
                .Replace("</strong>", "")
                .Replace("  ", " ")
                .Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataTable dt2 = (DataTable)dataGridView2.DataSource;
            dt2.Clear();
            Dictionary<string, int> dic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow dr in dt.Rows)
            {
                bool ad = "True".Equals(dr["车位"].ToString());
                if (checkBox2.Checked && ad)
                {
                    continue;
                }
                string title = dr["标题"].ToString();
                string[] keys = title.Split(' ');
                foreach (string key in keys)
                {
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        if (dic.ContainsKey(key))   // 是否存在
                        {
                            //dic.Add(key, dic[key] + 1);
                            dic[key] = dic[key] + 1;
                        }
                        else
                        {
                            dic.Add(key, 1);
                        }
                    }
                }
            }
            foreach (var key in dic.Keys)
            {
                var dr = dt2.NewRow();
                dr["单词"] = key;
                dr["中文"] = dicZH.ContainsKey(key) ? dicZH[key] : "";//getFy(key);
                dr["数量"] = dic[key];
                dt2.Rows.Add(dr);
            }
            label1.Text = "计算结束";
        }

        private void button4_Click(object sender1, EventArgs e1)
        {
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            string url = textBox1.Text;
            wb.Load(url);
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, e) =>
            {
                if (!e.IsLoading)
                {
                    e.Browser.MainFrame.GetSource(sv);
                    updateUrl(e.Browser.MainFrame.Url);
                    //wb.LoadingStateChanged -= handler;
                }
            };
            wb.LoadingStateChanged += handler;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            i = 0;
            dt.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            StringBuilder sb = new StringBuilder();
            sb.Append("var myset=function(){");
            sb.Append("document.getElementsByClassName('next')[0].click();");
            sb.Append("};setTimeout(myset(),3000);");
            wb.ExecuteScriptAsync(sb.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
