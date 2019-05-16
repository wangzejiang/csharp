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

namespace anylsycm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            InitBrowser("https://sycm.taobao.com");
        }

        public ChromiumWebBrowser browser;
        public void InitBrowser(string url)
        {
            browser = new ChromiumWebBrowser(url);
            tabPage1.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
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
                    browser.Load(sb.ToString());
                    return;
                }
            }
            MessageBox.Show("over" + staticnum);
        }

        private void runjs()
        {
            browser.ExecuteScriptAsync(File.ReadAllText(Utils.getConfig(@"cc.js")));
        }

        private string getElemetValue(string callMethod)
        {
            Task<JavascriptResponse> t = browser.EvaluateScriptAsync(callMethod);
            t.Wait();
            if (t.Result.Result != null)
            {
                return t.Result.Result.ToString();
            }
            return null;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync(File.ReadAllText(Utils.getConfig(@"main.js")));
            Random ro = new Random();
            int interval = ro.Next(2000, 5000);
            Console.WriteLine(interval);
            timer1.Interval = interval;
            string date, key, num = null;
            // 获取日期
            date = getElemetValue("getDate()");
            if (date == null) return;
            // 获取单词
            key = getElemetValue("getKey()");
            if (key == null) return;
            // 获取数字
            num = getElemetValue("getNumber()");
            if (num == null) {
                if(date!=null && key != null) {
                    browser.ExecuteScriptAsync("window.location.reload();");
                }
                return;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            runjs();
        }
    }
}
