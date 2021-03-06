﻿using System;
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
using System.Xml;

namespace 生意参谋下载器
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private MyWebBrowser webBrowser1;

        private void Form2_Load(object sender, EventArgs e)
        {
            webBrowser1 = new MyWebBrowser();
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(3, 3);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(886, 373);
            webBrowser1.TabIndex = 0;
            tabPage1.Controls.Add(this.webBrowser1);
            webBrowser1.Navigate("https://mai.taobao.com");
            BindingComboBox();
        }

        private DataTable table = null;

        private void BindingComboBox()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"Total.xml");
            //Console.WriteLine(ConvertDataSetToXML(ds));
            table = ds.Tables["Commbox"];
            table.Columns.Add("brandId|brandName", typeof(string), string.Format("{0}+'|'+{1}", "brandName", "brandId"));
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "brandId";
            comboBox1.DisplayMember = "brandId|brandName";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public static string ConvertDataSetToXML(DataSet xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                //从stream装载到XmlTextReader
                writer = new XmlTextWriter(stream, Encoding.Unicode);
                //用WriteXml方法写入文件.
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                UnicodeEncoding utf = new UnicodeEncoding();
                return utf.GetString(arr).Trim();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string name = comboBox1.Text;
            string id = comboBox1.SelectedValue as string;
            DataRow[] row = table.Select(string.Format("brandId='{0}'", id));
            if (row.Length <= 0)
            {
                MessageBox.Show("Test");
                return;
            }
            if (id == "0")
            {
                MessageBox.Show("Test");
                return;
            }
            string name = row[0]["brandName"].ToString();
            DateTime date = DateTime.Now.AddDays(-1);  //昨天
            int day = 0;
            for (int i = 0; i < 29; i++)
            {
                string datestr = date.AddDays(day--).ToString("yyyy-MM-dd");
                string path2 = string.Format(@"D:/sycmData/{0}", name);
                string path = string.Format(@"D:/sycmData/{0}/{1}_{2}.xls", name, id, datestr);
                Console.WriteLine(string.Format("file:{0}", path));
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                if (!File.Exists(path))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("https://sycm.taobao.com/bda/download/excel/items/itemanaly/ItemKeywordAnalysisExcel.do");
                    sb.Append("?device=2&itemId={0}&dateRange={1}|{2}&dateType=recent1&order=avgSeRank&orderType=asc&search=&searchType=taobao");
                    string url = string.Format(sb.ToString(), id, datestr, datestr);
                    Console.WriteLine(url);
                    webBrowser1.DownloadFile(url, path);
                    Thread.Sleep(1000);
                }
            }
            MessageBox.Show("下载完成");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindingComboBox();
        }
    }
}
