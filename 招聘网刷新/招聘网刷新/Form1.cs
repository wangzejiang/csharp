using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 招聘网刷新
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
        }

        private void button1_Click(object sender1, EventArgs e1)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            refash();
            tabControl1.SelectedTab = tabPage2;
            timer1.Stop();
            timer1.Interval = 1000;
            timer1.Start();
        }
        
        private int i = 0;

        private void tologin()
        {
            //StringVisitor sv = new StringVisitor();
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            string url = "http://www.stzp.cn/login/entlogin.aspx";
            wb.Load(url);

            //EventHandler<LoadingStateChangedEventArgs> handler = null;
            //handler = (sender, e) =>
            //{
            //    if (!e.IsLoading)
            //    {
            //        e.Browser.MainFrame.GetSource(sv);
            //        //wb.LoadingStateChanged -= handler;
            //    }
            //};
            //wb.LoadingStateChanged += handler;
            //while (sv.Value == null || "".Equals(sv.Value))
            //{
            //    Application.DoEvents();
            //}
            //string text = sv.Value;
            //HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            //hd.LoadHtml(text);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            input();
        }

        private void input()
        {
            var wb = getChromiumWebBrowser(tabPage1);
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("var myset=function(){");
                sb.Append("document.getElementById('ctl00_ContentPlaceHolder1_txtLoginID').value='13825856178';");
                sb.Append("document.getElementById('ctl00_ContentPlaceHolder1_txtLoginPwd').value='13825856178';");
                sb.Append("};setTimeout(myset(),3000);");
                wb.ExecuteScriptAsync(sb.ToString());
            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            //textBox1.Text += i + ".";
            int num = int.Parse(textBox2.Text);
            if (i > num * 60)
            {
                i = 0;
                refash();
            }
            if (i > num * 60-1)
            {
                refash2();
            }
        }
        
        private void refash()
        {
            var wb = getChromiumWebBrowser(tabPage1);
            string url = "http://www.stzp.cn/ent/refresh_offer1.aspx";
            wb.Load(url);
            textBox1.Text += "refresh:" + DateTime.Now.ToString() + "\r\n";
        }

        private void refash2()
        {
            string name = textBox3.Text;
            StringVisitor sv = new StringVisitor();
            var wb = getChromiumWebBrowser(tabPage1);
            string url = "http://www.stzp.cn/ent/mgjoblist.aspx";
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
            HtmlAgilityPack.HtmlNode node =
                hd.DocumentNode.SelectSingleNode("//*[@id='"+name+"']");
            if (node == null)
            {
                Console.WriteLine("nulll");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("var myset=function(){");
                sb.Append("document.getElementById('" + name + "').click();");
                sb.Append("};setTimeout(myset(),3000);");
                wb.ExecuteScriptAsync(sb.ToString());
                Console.WriteLine(node.InnerText);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.ShowInTaskbar = false;
            tologin();
            timer2.Start();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refash();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refash2();
        }
    }
}
