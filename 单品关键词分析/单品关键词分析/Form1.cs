using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 单品关键词分析
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = @"xxx.txt";

        string titleName = "";

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "生意参谋平台Excel文件|*.xls";
            openFileDialog1.DefaultExt = ".xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("关键词", typeof(string));
                dt.Columns.Add("浏览量", typeof(float));
                dt.Columns.Add("访客数", typeof(float));
                dt.Columns.Add("人均浏览量", typeof(float));
                dt.Columns.Add("跳失率", typeof(float));
                dt.Columns.Add("跳失人数", typeof(float)); 
                dt.Columns.Add("支付买家数", typeof(float));
                dt.Columns.Add("支付商品件数", typeof(float));
                dt.Columns.Add("支付金额", typeof(float));
                dt.Columns.Add("支付转化率", typeof(float));
                dt.Columns.Add("日期", typeof(string));

                string[] fns = openFileDialog1.FileNames;
                if(fns.Length > 0)
                {
                    string fpath = Path.GetFullPath(fns[0]);
                    string[] fpaths = fpath.Split('\\');
                    titleName = fpaths[2];
                }
                foreach (var f in fns)
                {
                    DataTable rsdt = null;
                    try
                    {
                        rsdt = excelToDataTable(f);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(f);
                        return;
                    }
                    DataRowCollection rsdr = rsdt.Rows;
                    foreach (DataRow rs in rsdr)
                    {
                        DataRow dr = dt.NewRow();
                        dr["关键词"] = rs[0].ToString();
                        int i = 5;
                        dr["浏览量"] = toFloat(rs[i++]);
                        var 访客数 = toFloat(rs[i++]);
                        dr["访客数"] = 访客数;
                        dr["人均浏览量"] = toFloat(rs[i++]);
                        var 跳失率 = toFloat(rs[i++]);
                        dr["跳失率"] = 跳失率;
                        dr["跳失人数"] = 访客数 * 跳失率 / 100;
                        dr["支付买家数"] = toFloat(rs[i++]);
                        dr["支付商品件数"] = toFloat(rs[i++]);
                        dr["支付金额"] = toFloat(rs[i++]);
                        dr["支付转化率"] = toFloat(rs[i++]);
                        dr["日期"] = f.Substring(f.IndexOf("_") + 1, 10);
                        dt.Rows.Add(dr);
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }

        public float toFloat(object obj)
        {
            float ret = 0f;
            string str = obj.ToString().Replace("%", "").Replace("-", "");
            float.TryParse(str, out ret);
            return ret;
        }

        public DataTable excelToDataTable(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            string[] strTableNames = new string[dtSheetName.Rows.Count];
            for (int k = 0; k < dtSheetName.Rows.Count; k++)
            {
                strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
            }
            OleDbDataAdapter myCommand = null;
            DataTable dt = new DataTable();
            string strExcel = "select * from [" + strTableNames[0] + "]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            dt = new DataTable();
            myCommand.Fill(dt);
            conn.Close();
            dt.Rows.RemoveAt(0);
            dt.Rows.RemoveAt(0);
            dt.Rows.RemoveAt(0);
            dt.Rows.RemoveAt(0);
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            string str = textBox1.Text;
            if (textBox2.Text.IndexOf(str) == -1)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.Write(string.Format("{0}:{1}:{2}",titleName, DateTime.Now.ToLongDateString(), str));
                    sw.WriteLine();
                    sw.Close();
                }
            }
            using (StreamReader reader = new StreamReader(path))
            {
                textBox2.Text = reader.ReadToEnd();
                reader.Close();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("词", typeof(string));
            dt.Columns.Add("浏览量", typeof(float));
            dt.Columns.Add("访客数", typeof(float));
            dt.Columns.Add("人均浏览量", typeof(float));
            dt.Columns.Add("平均跳失率", typeof(float));
            dt.Columns.Add("跳失率", typeof(float));
            dt.Columns.Add("支付买家数", typeof(float));
            dt.Columns.Add("支付商品件数", typeof(float));
            dt.Columns.Add("支付金额", typeof(float));
            dt.Columns.Add("平均支付转化率", typeof(float));
            dt.Columns.Add("支付转化率", typeof(float));
            DataTable ds = (DataTable)dataGridView1.DataSource;
            if (ds == null || ds.Rows.Count == 0) return;
            string[] ss = str.Split(' ');
            foreach (string s in ss)
            {
                DataRow dr = dt.NewRow();
                dr["词"] = s;
                dr["浏览量"] = toFloat(ds.Compute("Sum(浏览量)", "关键词 like '%" + s + "%'"));
                dr["访客数"] = toFloat(ds.Compute("Sum(访客数)", "关键词 like '%" + s + "%'"));
                dr["人均浏览量"] = toFloat(ds.Compute("Sum(人均浏览量)", "关键词 like '%" + s + "%'"));
                dr["平均跳失率"] = toFloat(ds.Compute("Sum(跳失率)/Count(跳失率)", "关键词 like '%" + s + "%'"));
                dr["跳失率"] = toFloat(ds.Compute("Sum(跳失人数)/Sum(访客数)*100", "关键词 like '%" + s + "%'"));
                dr["支付买家数"] = toFloat(ds.Compute("Sum(支付买家数)", "关键词 like '%" + s + "%'"));
                dr["支付商品件数"] = toFloat(ds.Compute("Sum(支付商品件数)", "关键词 like '%" + s + "%'"));
                dr["支付金额"] = toFloat(ds.Compute("Sum(支付金额)", "关键词 like '%" + s + "%'"));
                dr["平均支付转化率"] = toFloat(ds.Compute("Sum(支付转化率)/Count(支付转化率)", "关键词 like '%" + s + "%'"));
                dr["支付转化率"] = toFloat(ds.Compute("Sum(支付买家数)/Sum(访客数)*100", "关键词 like '%" + s + "%'"));
                dt.Rows.Add(dr);
            }
            dataGridView2.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tj("访客数");
        }

        private void tj(string name, bool isLv = true)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = textBox1.Text;
            }
            string str = textBox3.Text;
            string[] ss = str.Split(' ');
            foreach (string s in ss)
            {
                initChart(name, s, isLv);
            }
        }

        private void initChart(string tj, string word, bool isLv = true)
        {
            DataTable ds = (DataTable)dataGridView1.DataSource;
            var query = from t in ds.AsEnumerable().Where(dd => dd.Field<string>("关键词").IndexOf(word) > -1)
                        group t by new { 日期 = t.Field<string>("日期") } into m
                        select new
                        {
                            日期 = m.Key.日期,
                            统计 = isLv ? m.Sum(n => n.Field<float>(tj)) :( m.Sum(n => n.Field<float>(tj)) / m.Sum(n => n.Field<float>("访客数")))
                        };
            var s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.BorderWidth = 2;
            s.XValueType = ChartValueType.DateTime;
            s.Name = word;
            var list = query.ToList();
            DateTime dt = DateTime.Now;
            foreach (var item in list)
            {
                dt = DateTime.ParseExact(item.日期, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                s.Points.AddXY(dt, item.统计);
                //Console.WriteLine(item.日期 + "\t" + item.统计);
            }
            //s.ToolTip = "#VALX,#VAL";
            s.IsValueShownAsLabel = true;
            chart1.Series.Add(s);
            //chart1.ChartAreas[0].AxisX.Minimum = dt.AddSeconds(-1).ToOADate();
            //chart1.ChartAreas[0].AxisX.Maximum = dt.AddSeconds(-1).AddMonths(1).ToOADate();
        }

        void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                Series series = e.HitTestResult.Series;
                DataPoint dp = series.Points[i];
                e.Text = string.Format("{0}:{1}", series.Name, dp.YValues[0]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            chart1.GetToolTipText += new EventHandler<ToolTipEventArgs>(chart_GetToolTipText);

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    textBox2.Text = reader.ReadToEnd();
                    reader.Close();
                }
                using (StreamReader reader = new StreamReader(path))
                {
                    string str = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        str = reader.ReadLine();
                    }
                    if(str!= null && str.Length > 0)
                    {
                        textBox1.Text = str.Split(':')[2];
                    }
                    reader.Close();
                }
            }
            else
            {
                File.Create(path).Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)dataGridView1.DataSource;
            ds.Clear();
            DataTable ds2 = (DataTable)dataGridView2.DataSource;
            ds2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tj("支付买家数");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tj("支付转化率",false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tj("支付金额");
        }
    }
}
