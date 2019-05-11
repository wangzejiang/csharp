using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "生意参谋平台Excel文件|*.xls";
            openFileDialog1.DefaultExt = ".xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("关键词", typeof(string));
                dt.Columns.Add("访客数", typeof(float));
                dt.Columns.Add("日期", typeof(string));

                string[] fns = openFileDialog1.FileNames;
                foreach (var f in fns)
                {
                    DataTable rsdt = null;
                    try
                    {
                        rsdt = excelToDataTable(f);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(f + ex.Message);
                        return;
                    }
                    DataRowCollection rsdr = rsdt.Rows;
                    foreach (DataRow rs in rsdr)
                    {
                        DataRow dr = dt.NewRow();
                        dr["关键词"] = rs[0].ToString();
                        dr["访客数"] = toFloat(rs[1]);
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
            DataTable dt = new DataTable();
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
            return dt;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = (DataTable)dataGridView1.DataSource;
            DataTable dt = new DataTable();
            dt.Columns.Add("日期", typeof(string));
            dt.Columns.Add("统计", typeof(float));
            string[] keys = textBox1.Text.Split(',');
            foreach (var key in keys)
            {
                dt.Columns.Add(key, typeof(float));
            }
            DateTime now = DateTime.Now.AddHours(-8).AddDays(-1);
            for (int i = 0; i < 29; i++)
            {
                string datestr = now.AddDays(-i).ToString("yyyy-MM-dd");
                DataRow row = dt.NewRow();
                row["日期"] = datestr;
                float 统计 = 0f;
                foreach (var key in keys)
                {
                    string sql = string.Format("日期 ='{0}' and 关键词='{1}'", datestr, key);
                    DataRow[] datarows = data.Select(sql);
                    string number = datarows.Length == 0 ? "0" : (datarows.Length == 1 ? datarows[0]["访客数"].ToString() : "99999999");

                    float 自己 = toFloat(number);
                    string path = string.Format(@"../../sycmGData/{0}_{1}.txt", key, datestr);
                    float 市场 = File.Exists(path) ? toFloat(File.ReadAllText(path)) : -1f;
                    float 比例 = 自己 / 市场 * 1000;
                    统计 += 比例;
                    row[key] = 比例;
                }
                row["统计"] = float.Parse(统计.ToString("#0.00"));
                dt.Rows.Add(row);
            }
            dataGridView2.DataSource = dt;

            // 设置报表
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            var s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.BorderWidth = 3;
            s.XValueType = ChartValueType.DateTime;
            s.Name = "xxxx";
            DataRow[] dataRows = dt.Select("1=1", "日期 asc");
            foreach (DataRow row in dataRows)
            {
                string 日期 = (string)row["日期"];
                int 统计 = (int)((float)row["统计"]/1);
                s.Points.AddXY(日期, 统计);
                //Console.WriteLine(item.日期 + "\t" + item.统计);
            }
            s.IsValueShownAsLabel = true;
            chart1.Series.Add(s);
        }
    }
}
