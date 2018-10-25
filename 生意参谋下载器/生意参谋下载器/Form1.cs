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

namespace 生意参谋下载器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser wb = null;

        private void button1_Click(object sender, EventArgs e)
        {
            wb = new ChromiumWebBrowser("");
            wb.Dock = DockStyle.Fill;
            wb.DownloadHandler = new DownloadHandler();
            tabPage1.Controls.Add(wb);
            wb.Load("https://sycm.taobao.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cef.Initialize(new CefSettings());
            var cookieManager = Cef.GetGlobalCookieManager();
            cookieManager.SetStoragePath(Environment.CurrentDirectory, true);
        }

        internal class DownloadHandler : IDownloadHandler
        {
            public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
            {
                if (!callback.IsDisposed)
                {
                    using (callback)
                    {
                        callback.Continue(@"D:\" + downloadItem.SuggestedFileName, showDialog: false);
                    }
                }
            }

            public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
            {
                //if (downloadItem.IsComplete)
                //{
                //}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = string.Format("https://sycm.taobao.com/bda/download/excel/items/itemanaly/ItemKeywordAnalysisExcel.do?device=2&itemId=578432511123&dateRange=2018-10-21|2018-10-21&dateType=recent1&order=avgSeRank&orderType=asc&search=&searchType=taobao", "");
            wb.Load(url);
        }
    }
}
