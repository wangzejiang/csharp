using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jdtry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var settings = new CefSettings();
            settings.CachePath = @"cache";
            Cef.Initialize(settings);
            tabPage1.Controls.Add(createChromiumWebBrowser());
            tabPage2.Controls.Add(createChromiumWebBrowser());
        }

        private ChromiumWebBrowser createChromiumWebBrowser(string url = "about:blank")
        {
            ChromiumWebBrowser wb = new ChromiumWebBrowser(url)
            {
                JsDialogHandler = new JsDialogHandler(),
            };
            wb.Name = "ChromiumWebBrowser";
            return wb;
        }

        private ChromiumWebBrowser getChromiumWebBrowser(Control tab)
        {
            return (ChromiumWebBrowser)tab.Controls["ChromiumWebBrowser"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            string url = "https://passport.jd.com/new/login.aspx";
            wb.Load(url);

            timer1.Interval = 1000 * 10;
            timer2.Start();
        }

        private List<string> exec(int page)
        {
            StringVisitor sv = new StringVisitor();
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            string url = string.Format("https://try.jd.com/activity/getActivityList?page={0}&activityType=1&cids={1}", page,textBox2.Text);
            wb.Load(url);
            wb.GetBrowser().MainFrame.GetSource(sv);
            while (sv.Value == null || "".Equals(sv.Value))
            {
                Application.DoEvents();
            }
            string text = sv.Value;
            WaitFor(2000);
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNode node =
                hd.DocumentNode.SelectSingleNode("//*[@id='goods-list']/div[2]/div/ul");
            List<string> urls = new List<string>();
            if (node == null) return urls;
            foreach (var item in node.ChildNodes)
            {
                string className = item.GetAttributeValue("class", "");
                if ("item".Equals(className))
                {
                    HtmlAgilityPack.HtmlNode div = item.SelectSingleNode("div/div[6]");
                    string str = div.InnerText.Trim();
                    Console.WriteLine(str); 
                    string activity_id = item.GetAttributeValue("activity_id", null);
                    if (activity_id != null && "我要申请".Equals(str))
                    {
                        string uurl = string.Format("https://try.jd.com/{0}.html", activity_id);
                        Console.WriteLine(uurl);
                        urls.Add(uurl);
                    }
                }
            }
            return urls;
        }

        Stack<string> urls = new Stack<string>();

        static public void WaitFor(int ms)
        {
            DateTime time = DateTime.Now;
            while (true)
            {
                Application.DoEvents();
                TimeSpan span = DateTime.Now - time;
                if (span.TotalMilliseconds > ms) break;
            }
        }

        private void button1_Click(object sender1, EventArgs e1)
        {
            timer1.Stop();
            urls.Clear();
            StringVisitor sv = new StringVisitor();
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            string url = string.Format("https://try.jd.com/activity/getActivityList?page=1&activityType=1&cids={0}",textBox2.Text);
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
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNode topPage =
                 hd.DocumentNode.SelectSingleNode("//*[@id='J_topPage']/span/i");
            if (topPage == null) return;
            Console.WriteLine(topPage.InnerText);
            int page = int.Parse(topPage.InnerText);
            for (int i = 1; i <= page; i++)
            {
                List<string> list = exec(i);
                foreach (var item in list)
                {
                    urls.Push(item);
                }
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender1, EventArgs e1)
        {
            if (urls.Count <= 0) return;
            string url = urls.Pop();
            textBox1.Text = url;
            Console.WriteLine(url);
            StringVisitor sv = new StringVisitor();
            var wb = getChromiumWebBrowser(tabPage2);
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
            wb.ExecuteScriptAsync(File.ReadAllText("text.js"));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0}", urls.Count);
        }
    }
}
