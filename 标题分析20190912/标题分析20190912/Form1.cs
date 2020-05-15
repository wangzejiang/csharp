using System;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace 标题分析20190912
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DataTable excelToDataTable(string Path)
        {

            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
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
            dt.Rows.RemoveAt(0);
            return dt;
        }

        public float toFloat(object obj)
        {
            float ret = 0f;
            string str = obj.ToString().Replace("%", "").Replace("-", "");
            float.TryParse(str, out ret);
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "生意参谋平台Excel文件|*.xls";
            openFileDialog1.DefaultExt = ".xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = newDataTable();
                string[] fns = openFileDialog1.FileNames;
                if (fns.Length > 0)
                {
                    string fpath = Path.GetFullPath(fns[0]);
                    string[] fpaths = fpath.Split('\\');
                  //  titleName = fpaths[2];
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
                        MessageBox.Show(f + ex.Message);
                        return;
                    }
                    DataRowCollection rsdr = rsdt.Rows;
                    foreach (DataRow rs in rsdr)
                    {
                        int i = 0;
                        DataRow dr = dt.NewRow();
                        dr["关键词"] = rs[i++].ToString();
                        dr["访客数"] = toFloat(rs[i++]);
                        dr["浏览量"] = toFloat(rs[i++]);
                        dr["浏览量占比"] = toFloat(rs[i++]);
                        dr["店内跳转人数"] = toFloat(rs[i++]);
                        dr["跳出本店人数"] = toFloat(rs[i++]);
                        dr["收藏人数"] = toFloat(rs[i++]);
                        dr["加购人数"] = toFloat(rs[i++]);
                        dr["下单买家数"] = toFloat(rs[i++]);
                        dr["下单转化率"] = toFloat(rs[i++]);
                        dr["支付件数"] = toFloat(rs[i++]);
                        dr["支付买家数"] = toFloat(rs[i++]);
                        dr["支付转化率"] = toFloat(rs[i++]);
                        dr["直接支付买家数"] = toFloat(rs[i++]);
                        dr["粉丝支付买家数"] = toFloat(rs[i++]);
                        dr["收藏商品支付买家数"] = toFloat(rs[i++]);
                        dr["加购商品支付买家数"] = toFloat(rs[i++]);
                        dt.Rows.Add(dr);
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }

        private DataTable newDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("关键词", typeof(string));
            dt.Columns.Add("访客数", typeof(float));
            dt.Columns.Add("浏览量", typeof(float));
            dt.Columns.Add("浏览量占比", typeof(float));
            dt.Columns.Add("店内跳转人数", typeof(float));
            dt.Columns.Add("跳出本店人数", typeof(float));
            dt.Columns.Add("收藏人数", typeof(float));
            dt.Columns.Add("加购人数", typeof(float));
            dt.Columns.Add("下单买家数", typeof(float));
            dt.Columns.Add("下单转化率", typeof(float));
            dt.Columns.Add("支付件数", typeof(float));
            dt.Columns.Add("支付买家数", typeof(float));
            dt.Columns.Add("支付转化率", typeof(float));
            dt.Columns.Add("直接支付买家数", typeof(float));
            dt.Columns.Add("粉丝支付买家数", typeof(float));
            dt.Columns.Add("收藏商品支付买家数", typeof(float));
            dt.Columns.Add("加购商品支付买家数", typeof(float));
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0) return;

            if(textBox1.Text.IndexOf(" ") <= -1)
            {
                List<char> clist = new List<char>();
                foreach (char c in textBox1.Text)
                {
                    clist.Add(c);
                }
                string str = string.Join(" ", clist);
                textBox1.Text = str;
            }

            DataTable dt = newDataTable();
            dt.Columns.Add("平均支付转化率", typeof(float));
            dt.Columns.Add("平均下单转化率", typeof(float));

            string[] word = textBox1.Text.Split(' ');
            DataTable ds = (DataTable)dataGridView1.DataSource;
            if (ds == null || ds.Rows.Count == 0) return;
            foreach (var s in word)
            {
                DataRow dr = dt.NewRow();
                dr["关键词"] = s;
                dr["访客数"] = toFloat(ds.Compute("Sum(访客数)", "关键词 like '%" + s + "%'"));
                dr["浏览量"] = toFloat(ds.Compute("Sum(浏览量)", "关键词 like '%" + s + "%'"));
                dr["浏览量占比"] = toFloat(ds.Compute("Sum(浏览量占比)", "关键词 like '%" + s + "%'"));
                dr["店内跳转人数"] = toFloat(ds.Compute("Sum(店内跳转人数)", "关键词 like '%" + s + "%'"));
                dr["跳出本店人数"] = toFloat(ds.Compute("Sum(跳出本店人数)", "关键词 like '%" + s + "%'"));
                dr["收藏人数"] = toFloat(ds.Compute("Sum(收藏人数)", "关键词 like '%" + s + "%'"));
                dr["加购人数"] = toFloat(ds.Compute("Sum(加购人数)", "关键词 like '%" + s + "%'"));
                dr["下单买家数"] = toFloat(ds.Compute("Sum(下单买家数)", "关键词 like '%" + s + "%'"));
                dr["平均下单转化率"] = toFloat(ds.Compute("Sum(下单转化率)/Count(支付转化率)", "关键词 like '%" + s + "%'"));
                dr["下单转化率"] = toFloat(ds.Compute("Sum(下单买家数)/Sum(访客数)", "关键词 like '%" + s + "%'"));
                dr["支付件数"] = toFloat(ds.Compute("Sum(支付件数)", "关键词 like '%" + s + "%'"));
                dr["支付买家数"] = toFloat(ds.Compute("Sum(支付买家数)", "关键词 like '%" + s + "%'"));
                dr["平均支付转化率"] = toFloat(ds.Compute("Sum(支付转化率)/Count(支付转化率)", "关键词 like '%" + s + "%'"));
                dr["支付转化率"] = toFloat(ds.Compute("Sum(支付买家数)/Sum(访客数)", "关键词 like '%" + s + "%'"));
                dr["直接支付买家数"] = toFloat(ds.Compute("Sum(直接支付买家数)", "关键词 like '%" + s + "%'"));
                dr["粉丝支付买家数"] = toFloat(ds.Compute("Sum(粉丝支付买家数)", "关键词 like '%" + s + "%'"));
                dr["收藏商品支付买家数"] = toFloat(ds.Compute("Sum(收藏商品支付买家数)", "关键词 like '%" + s + "%'"));
                dr["加购商品支付买家数"] = toFloat(ds.Compute("Sum(加购商品支付买家数)", "关键词 like '%" + s + "%'"));
                dt.Rows.Add(dr);
            }
            dataGridView2.DataSource = dt;

            DataTable dt2 = newDataTable();
            DataRow[] drs = ds.Select("支付买家数 > 0");
            foreach (var row in drs)
            {
                string wd = row["关键词"].ToString();
                bool flag = false;
                foreach (char c in wd)
                {
                    if (textBox1.Text.IndexOf(c) <= -1)   // 不存在的字
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    dt2.Rows.Add(row.ItemArray);
                }
            }
            dataGridView3.DataSource = dt2;
        }
    }
}
