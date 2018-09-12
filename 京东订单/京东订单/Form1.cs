using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 京东订单
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabPage1.Controls.Add(createChromiumWebBrowser());
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("订单编号", typeof(string)));
            dt.Columns.Add(new DataColumn("下单时间", typeof(string)));
            dt.Columns.Add(new DataColumn("姓名", typeof(string)));
            dt.Columns.Add(new DataColumn("电话", typeof(string)));
            dt.Columns.Add(new DataColumn("地址", typeof(string)));
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            var wb = getChromiumWebBrowser(tabPage1);
            login(wb, "user");
        }
        public void login(ChromiumWebBrowser wb, string userName, string url = "https://shop.jd.com/")
        {
            wb.RequestHandler = new MyRequestHandler(new ResourceType[] {  });
            if (wb.GetBrowser().MainFrame.Url.StartsWith(url))
            {
                //inputUser(wb, userName);
                return;
            }
            wb.Load(url);
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, e) =>
            {
                if (!e.IsLoading)
                {
                    if (e.Browser.MainFrame.Url.StartsWith(url))
                    {
                        //inputUser(wb, userName);
                    }
                    wb.LoadingStateChanged -= handler;
                }
            };
            wb.LoadingStateChanged += handler;
        }

        private ChromiumWebBrowser getChromiumWebBrowser(Control tab)
        {
  //          Utils.setCef("user2");
            return (ChromiumWebBrowser)tab.Controls["ChromiumWebBrowser"];
       }
        
        private ChromiumWebBrowser createChromiumWebBrowser(string url = "about:blank")
        {
            ChromiumWebBrowser wb = new ChromiumWebBrowser(url);
            wb.Name = "ChromiumWebBrowser";
            return wb;
        }

        private void button2_Click(object sender1, EventArgs e1)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Clear();
            string text = textBox1.Text;
            string[] order = text.Split(',');
            foreach(var orderid in order)
            {
                dt.Rows.Add(getDr(orderid));
            }
        }
        private void getOrder(string page)
        {
            var wb = getChromiumWebBrowser(tabPage1);
            wb.Load("https://order.shop.jd.com/order/sopUp_waitOutList.action?page=1");
            wb.RequestHandler = new MyRequestHandler(new ResourceType[] { ResourceType.Image, ResourceType.Stylesheet, ResourceType.Script, ResourceType.Media });
            StringVisitor sv = new StringVisitor();
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
                return;
            }
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNodeCollection nodes =
                hd.DocumentNode.SelectNodes("/html/body/div[2]/div/div[3]/div[1]/div/div/div[2]/table[3]/tbody");
            if (nodes == null)
            {
                return;
            }
            foreach (var note in nodes)
            {
                try
                {
                    HtmlAgilityPack.HtmlNode trNote = note.SelectSingleNode("tr[2]");
                    HtmlAgilityPack.HtmlNode tdNote = trNote.SelectSingleNode("td");
                    HtmlAgilityPack.HtmlNode spanNote = tdNote.SelectSingleNode("span[2]");
                    HtmlAgilityPack.HtmlNode aNote = spanNote.SelectSingleNode("a");
                    string orderid = aNote.InnerHtml;
                    Console.WriteLine("-->" + aNote.InnerHtml);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        private DataRow getDr(string orderid)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var dr = dt.NewRow();
            string addr = getAddr(orderid);
            HtmlAgilityPack.HtmlDocument hd2 = new HtmlAgilityPack.HtmlDocument();
            hd2.LoadHtml(addr);
            HtmlAgilityPack.HtmlNode nameNode = hd2.DocumentNode.SelectSingleNode("//*[@id='receiveData']/tbody/tr[2]/td[2]");
            HtmlAgilityPack.HtmlNode addrNode = hd2.DocumentNode.SelectSingleNode("//*[@id='receiveData']/tbody/tr[3]/td[2]");
            HtmlAgilityPack.HtmlNode timeNode = hd2.DocumentNode.SelectSingleNode("/html/body/div[1]/div[1]/ul/li[1]/p[2]");
            HtmlAgilityPack.HtmlNode accesskeyNode = hd2.DocumentNode.SelectSingleNode("//*[@id='viewOrderMobile']");
            string accesskey = accesskeyNode.GetAttributeValue("accesskey", "");
            string iphone = getIphone(orderid, accesskey);
            Console.WriteLine("-->" + nameNode.InnerText);
            Console.WriteLine("-->" + addrNode.InnerText);
            Console.WriteLine("-->" + timeNode.InnerText);
            Console.WriteLine("-->" + iphone);
            dr["订单编号"] = orderid;
            dr["下单时间"] = timeNode.InnerText;
            dr["姓名"] = nameNode.InnerText;
            dr["电话"] = iphone;
            dr["地址"] = addrNode.InnerText;
            return dr;
        }
        private string getIphone(string id,string accessKey)
        {
            string url = string.Format("https://neworder.shop.jd.com/order/json/phoneSensltiveInfo?orderId={0}&accessKey={1}&accessType=1",id, accessKey);
            var wb = getChromiumWebBrowser(tabPage1);
            wb.Load(url);
            wb.RequestHandler = new MyRequestHandler(new ResourceType[] { ResourceType.Image, ResourceType.Stylesheet, ResourceType.Script, ResourceType.Media });
            StringVisitor sv = new StringVisitor();
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
                return null;
            }
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(text);
            HtmlAgilityPack.HtmlNode nameNode = hd.DocumentNode.SelectSingleNode("/html/body/pre/text()");
            var dy = JsonConvert.DeserializeObject<dynamic>(nameNode.InnerText);
            var model = dy["model"];
            var iphone = model["phone"];
            var mobile = model["mobile"];
            return iphone;
        }
        private string getAddr(string id)
        {
            var wb = getChromiumWebBrowser(tabPage1);
            wb.Load("https://neworder.shop.jd.com/order/orderDetail?orderId="+id);
            wb.RequestHandler = new MyRequestHandler(new ResourceType[] { ResourceType.Image, ResourceType.Stylesheet, ResourceType.Script, ResourceType.Media });
            StringVisitor sv = new StringVisitor();
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
                return null;
            }
            return text;
        }
    }
}
