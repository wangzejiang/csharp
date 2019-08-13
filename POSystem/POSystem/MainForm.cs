using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public partial class MainForm : Form
    {
        public LoginForm loginForm { get; set; }
        public MainForm(LoginForm _loginForm)
        {
            this.loginForm = _loginForm;
            InitializeComponent();
        }

        private void 商品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage商品列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage商品列表;
        }

        private void PoSystem_Load(object sender, EventArgs e)
        {
            var tabpages = this.MainTabControl.TabPages;
            foreach (TabPage page in tabpages)
            {
                page.Parent = null;
            }
            this.tabPage欢迎页.Parent = this.MainTabControl;
        }

        private void MainTabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainTabControl.SelectedTab.Text.Equals(this.tabPage欢迎页.Text)) return;
            MainTabControl.SelectedTab.Parent = null;
        }

        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage添加商品.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage添加商品;
        }

        private void 新订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage新订单.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage新订单;
        }

        private void 订单查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.tabPage订单列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage订单列表;
        }

        private void 新增客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage添加客户.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage添加客户;
        }

        private void 客户查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage客户列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage客户列表;

            this.dgvCustomers.DataSource = CustomerInfoManager.GetCustomerInfoAll();

        }

        private void 查询_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = false;
            //this.Hide();
            //loginForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dgvCustomers.DataSource = CustomerInfoManager.GetCustomerInfoAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerInfo cInfo = new CustomerInfo();
            cInfo.CName = textBox_cName.Text.Trim();
            cInfo.CPhone = textBox_cPhone.Text.Trim();
            cInfo.CAddress = textBox_cAddress.Text.Trim();
            int idx = CustomerInfoManager.AddCustomerInfo(cInfo);
            if (idx > 0)
            {
                MessageBoxEx.Show(this, "添加成功！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductInfo pInfo = new ProductInfo();
            //pInfo.
            pInfo.PName = textBox_pName.Text.Trim();
            pInfo.PPrice = float.Parse(textBox_pPrice.Text.Trim());
            pInfo.PWeigth = float.Parse(textBox_pWeight.Text.Trim());
            pInfo.PSuppliter = textBox_pSuppliter.Text.Trim();
            pInfo.PNumber = textBox_pNumber.Text.Trim();
            ProductInfoManager.AddProductInfo(pInfo);
        }
        private Attachment attachment;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "iamge files(*.jpg)|*.jpg";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                attachment = new Attachment();
                byte[] bs = File.ReadAllBytes(ofd.FileName);
                attachment.Content = bs;
                attachment.Length = bs.Length;
                pictureBox_pImage.Image = Image.FromFile(ofd.FileName);
               // AttachmentManager.AddAttachment(attachment); //it test
            }
        }
    }
}
