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
            string[] keys = textBox1.Text.Split(',');
            foreach (var key in keys)
            {
                dt.Columns.Add(key, typeof(float));
            }
            DateTime now = DateTime.Now.AddHours(-8).AddDays(-1);
            for (int i = 0; i < 30; i++)
            {
                string datestr = now.AddDays(-i).ToString("yyyy-MM-dd");
                DataRow row = dt.NewRow();
                foreach (var key in keys)
                {
                    string sql = string.Format("日期 ='{0}' and 关键词='{1}'", datestr, key);
                    DataRow[] datarows = data.Select(sql);
                    string number = datarows.Length == 0 ? "0" : (datarows.Length == 1 ? datarows[0]["访客数"].ToString() : "99999999");
                    row["日期"] = datestr;
                    float 自己 = toFloat(number);
                    string path = string.Format(@"../../sycmGData/{0}_{1}.txt", key, datestr);
                    float 市场 = File.Exists(path) ? toFloat(File.ReadAllText(path)) : -1f;
                    row[key] = 自己 / 市场 * 1000;
                }
                dt.Rows.Add(row);
            }
            dataGridView2.DataSource = dt;
        }
    }
}
