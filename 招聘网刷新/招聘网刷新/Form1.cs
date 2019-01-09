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
        }

        private void button1_Click(object sender1, EventArgs e1)
        {
            var wb1 = createChromiumWebBrowser("http://www.stzp.cn/login/entlogin.aspx");
            var wb2 = createChromiumWebBrowser("http://www.stzp.cn/ent/mgjoblist.aspx");
            tabPage1.Controls.Add(wb1);
            tabPage3.Controls.Add(wb2);
            input(wb1);
            input(wb2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            refash();
            timer1.Stop();
            timer1.Interval = 1000;
            timer1.Start();
        }
        
        private int ig = 0;
        
        private void input(ChromiumWebBrowser wb)
        {
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                StringBuilder sb = new StringBuilder();
                //sb.Append("var myset=function(){");
                sb.Append("document.getElementById('ctl00_ContentPlaceHolder1_txtLoginID').value='13825856178';");
                sb.Append("document.getElementById('ctl00_ContentPlaceHolder1_txtLoginPwd').value='13825856178';");
                //sb.Append("};setTimeout(myset(),3000);");
                wb.ExecuteScriptAsync(sb.ToString());
            };
            //wb.IsBrowserInitializedChanged += handler;
            wb.LoadingStateChanged += handler;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ig++;
            //textBox1.Text += i + ".";
            int num = int.Parse(textBox2.Text);
            int num2 = int.Parse(textBox3.Text);
            if (ig % (60 * num) == 0)
            {
                refash();
            }
            if (ig % (60 * num2) == 0)
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

        private int g_number = 0;

        private void refash2()
        {
            g_number++;
            if(g_number > 19)
            {
                g_number = 0;
            }
            string f = string.Format("ctl00_ContentPlaceHolder1_repJob_ctl{0:00}_lbIsRefresh", g_number);
            Console.WriteLine(f);
            StringVisitor sv = new StringVisitor();
            var wb = getChromiumWebBrowser(tabPage3);
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
                hd.DocumentNode.SelectSingleNode("//*[@id='"+f+"']");
            if (node == null)
            {
                Console.WriteLine("nulll");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("var myset=function(){");
                sb.Append("document.getElementById('" + f + "').click();");
                sb.Append("};setTimeout(myset(),3000);");
                wb.ExecuteScriptAsync(sb.ToString());
                Console.WriteLine(node.InnerText);
            }
            textBox1.Text += "refresh2:" + DateTime.Now.ToString() + "\r\n";
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
            var settings = new CefSettings();
            settings.CachePath = @"cache";
            Cef.Initialize(settings);
            ShowInTaskbar = false;
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
