using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace anylsycm
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
            textBox1.Text = Utils.readTopWords();
            webBrowser1 = new MyWebBrowser();
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(3, 3);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(886, 373);
            webBrowser1.TabIndex = 0;
            tabPage1.Controls.Add(this.webBrowser1);
            webBrowser1.Navigate("https://sycm.taobao.com");
            BindingComboBox();
        }

        private void BindingComboBox()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Utils.getConfig(@"Total.xml"));
            Console.WriteLine(ConvertDataSetToXML(ds));
            var table = ds.Tables["Commbox"];
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "brandId";
            comboBox1.DisplayMember = "brandName";
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
            string name = comboBox1.Text;
            string id = comboBox1.SelectedValue as string;
            if (id == "0")
            {
                MessageBox.Show("Test");
                return;
            }
            DateTime date = DateTime.Now.AddHours(-8).AddDays(getDay());  //昨天
            int day = 0;
            for (int i = 0; i < 29; i++)
            {
                string datestr = date.AddDays(day--).ToString("yyyy-MM-dd");
                string path2 = string.Format(Utils.getConfig(@"sycmData/{0}"), name);
                string path = string.Format(Utils.getConfig(@"sycmData/{0}/{1}_{2}.xls"), name, id, datestr);
                Console.WriteLine(string.Format("file:{0}", path));
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                if (!File.Exists(path))
                {
                    StringBuilder sb = new StringBuilder();
                    // sb.Append("https://sycm.taobao.com/bda/download/excel/items/itemanaly/ItemKeywordAnalysisExcel.do");
                    //sb.Append("?device=2&itemId={0}&dateRange={1}|{2}&dateType=recent1&order=avgSeRank&orderType=asc&search=&searchType=taobao");
                    sb.Append("https://sycm.taobao.com/flow/excel.do");
                    sb.Append("?_path_ =v3/new/excel/item/source/detail&order=desc&orderBy=uv&dateType=day&dateRange={1}|{2}");
                    sb.Append("&itemId={0}&device=2&pageId=23.s1150&pPageId=23&pageLevel=2&childPageType=se_keyword&belong=all");
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

        public DataTable excelToDataTable(string Path)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            excel.Visible = false;//设置调用引用的 Excel文件是否可见
            excel.DisplayAlerts = false;
            wb = excel.Workbooks.Open(Path);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            wb.Close();

            DataTable dt = new DataTable();
            try
            {
                string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", Path);
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string strExcel = "select * from [$A1:R65536]";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
                dt = new DataTable();
                myCommand.Fill(dt);
                conn.Close();
                dt.Rows.RemoveAt(0);
                dt.Rows.RemoveAt(0);
                dt.Rows.RemoveAt(0);
                dt.Rows.RemoveAt(0);
                dt.Rows.RemoveAt(0);
                dt.Rows.RemoveAt(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                File.Delete(Path);
            }
            return dt;
        }
        private int getDay()
        {
            return int.Parse(textBox3.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            string id = comboBox1.SelectedValue as string;
            if (id == "0")
            {
                MessageBox.Show("Test");
                return;
            }
            DateTime edate = DateTime.Now.AddHours(-8).AddDays(getDay());  //昨天
            DateTime sdate = edate.AddDays(-29);  //30
            string path2 = string.Format(Utils.getConfig(@"sycmData/{0}/30"), name);
            string path = string.Format(Utils.getConfig(@"sycmData/{0}/30/{1}_{2}_{3}.xls"), name, id, sdate.ToString("yyyy-MM-dd"), edate.ToString("yyyy-MM-dd"));
            Console.WriteLine(string.Format("file:{0}", path));
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }
            if (!File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("https://sycm.taobao.com/flow/excel.do");
                sb.Append("?_path_=v3/new/excel/item/source/detail&order=desc&orderBy=uv&dateType=recent30&dateRange={1}|{2}");
                sb.Append("&itemId={0}&device=2&pageId=23.s1150&pPageId=23&pageLevel=2&childPageType=se_keyword&belong=all");
                string url = string.Format(sb.ToString(), id, sdate.ToString("yyyy-MM-dd"), edate.ToString("yyyy-MM-dd"));
                Console.WriteLine(url);
                webBrowser1.DownloadFile(url, path);
                Thread.Sleep(1000);
            }
            StringBuilder text = new StringBuilder();
            DataRowCollection rsdr = excelToDataTable(path).Rows;
            for (int i = 0; i < int.Parse(textBox2.Text) && i < rsdr.Count; i++)
            {
                string key = rsdr[i][0].ToString();
                if ("其他".Equals(key) == false)
                {
                    text.Append(key).Append(",");
                }
            }
            if(text.Length > 0)
            {
                textBox1.Text = Utils.writeTopWords(text.Remove(text.Length - 1, 1).ToString());
                MessageBox.Show("下载完成");
            }
            else
            {
                MessageBox.Show("下载失败");
            }
        }
    }
}
