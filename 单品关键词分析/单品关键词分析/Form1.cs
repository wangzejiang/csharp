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

namespace 单品关键词分析
{
    public partial class Form1 : Form
    {
        public Form1()
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
                dt.Columns.Add("浏览量", typeof(float));
                dt.Columns.Add("访客数", typeof(float));
                dt.Columns.Add("人均浏览量", typeof(float));
                dt.Columns.Add("跳失率", typeof(float));
                dt.Columns.Add("支付买家数", typeof(float));
                dt.Columns.Add("支付商品件数", typeof(float));
                dt.Columns.Add("支付金额", typeof(float));
                dt.Columns.Add("支付转化率", typeof(float));
                dt.Columns.Add("日期", typeof(string));

                string[] fns = openFileDialog1.FileNames;
                foreach (var f in fns)
                {
                    DataTable rsdt = excelToDataTable(f);
                    DataRowCollection rsdr = rsdt.Rows;
                    foreach (DataRow rs in rsdr)
                    {
                        DataRow dr = dt.NewRow();
                        dr["关键词"] = rs[0].ToString();
                        int i = 5;
                        dr["浏览量"] = toFloat(rs[i++]);
                        dr["访客数"] = toFloat(rs[i++]);
                        dr["人均浏览量"] = toFloat(rs[i++]);
                        dr["跳失率"] = toFloat(rs[i++]);
                        dr["支付买家数"] = toFloat(rs[i++]);
                        dr["支付商品件数"] = toFloat(rs[i++]);
                        dr["支付金额"] = toFloat(rs[i++]);
                        dr["支付转化率"] = toFloat(rs[i++]);
                        dr["日期"] = f.Substring(f.IndexOf("_")+1,10);
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
            string str = textBox1.Text;
            string path = @"\xxx.txt";
            if (textBox2.Text.IndexOf(str) == -1)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.Write(str);
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
            dt.Columns.Add("跳失率", typeof(float));
            dt.Columns.Add("支付买家数", typeof(float));
            dt.Columns.Add("支付商品件数", typeof(float));
            dt.Columns.Add("支付金额", typeof(float));
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
                dr["跳失率"] = toFloat(ds.Compute("Sum(跳失率)/Count(跳失率)", "关键词 like '%" + s + "%'"));
                dr["支付买家数"] = toFloat(ds.Compute("Sum(支付买家数)", "关键词 like '%" + s + "%'"));
                dr["支付商品件数"] = toFloat(ds.Compute("Sum(支付商品件数)", "关键词 like '%" + s + "%'"));
                dr["支付金额"] = toFloat(ds.Compute("Sum(支付金额)", "关键词 like '%" + s + "%'"));
                dr["支付转化率"] = toFloat(ds.Compute("Sum(支付转化率)/Count(跳失率)", "关键词 like '%" + s + "%'"));
                dt.Rows.Add(dr);
            }
            dataGridView2.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"\xxx.txt";
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    textBox2.Text = reader.ReadToEnd();
                    reader.Close();
                }
                using (StreamReader reader = new StreamReader(path))
                {
                    textBox1.Text = reader.ReadLine();
                    reader.Close();
                }
            }
            else
            {
                File.Create(path).Close();
            }
        }
    }
}
