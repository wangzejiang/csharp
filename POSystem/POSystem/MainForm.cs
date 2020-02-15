using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        #region addMethod
        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage新增商品.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage新增商品;
        }
        private void 新订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage新订单.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage新订单;
        }
        private void 新增客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage新增客户.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage新增客户;
        }
        #endregion addMethod

        public void selectProduct(int? PID = -1)
        {
            ProductInfo pinfo = new ProductInfo();
            pinfo.PName = txt_SelPName.Text;
            pinfo.PNumber = txt_SelPNumber.Text;
            pinfo.PSuppliter = txt_SelPSuppliter.Text;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.DataSource = ProductInfoManager.GetProductInfoAll2(pinfo);
            dgvProducts.Columns["pNumber"].HeaderCell.Value = "编号";
            dgvProducts.Columns["pName"].HeaderCell.Value = "名称";
            dgvProducts.Columns["PWeigth"].HeaderCell.Value = "重量";
            dgvProducts.Columns["PSuppliter"].HeaderCell.Value = "供应商";
            dgvProducts.Columns["PPrice"].HeaderCell.Value = "价格";
            dgvProducts.Columns["PRemark"].HeaderCell.Value = "备注";
            dgvProducts.Columns["PID"].Visible = false;
            dgvProducts.Columns["CreateDate"].Visible = false;
            dgvProducts.Columns["UpdateDate"].Visible = false;
            dgvProducts.Columns["PImageID"].Visible = false;
            dgvProducts.Columns["pImageBytes"].HeaderCell.Value = "产品图片";
            if (PID >= 0)
            {
                string sPID = string.Format("{0}", PID);
                for (int i = 0; i < dgvProducts.RowCount; i++)
                {
                    if (dgvProducts.Rows[i].Cells["PID"].Value.ToString().Equals(sPID))
                    {
                        dgvProducts.ClearSelection();
                        dgvProducts.FirstDisplayedScrollingRowIndex = i;
                        dgvProducts.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }
        public void selectCustomers(int? CID = -1)
        {
            CustomerInfo cinfo = new CustomerInfo();
            cinfo.CName = txt_SelCName.Text;
            cinfo.CPhone = txt_SelCPhone.Text;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.DataSource = CustomerInfoManager.GetCustomerInfoAll(cinfo);
            dgvCustomers.Columns["CID"].HeaderCell.Value = "编号";
            dgvCustomers.Columns["CName"].HeaderCell.Value = "客户名称";
            dgvCustomers.Columns["CPhone"].HeaderCell.Value = "联系方式";
            dgvCustomers.Columns["CAddress"].HeaderCell.Value = "联系地址";
            dgvCustomers.Columns["CreateDate"].Visible = false;
            dgvCustomers.Columns["UpdateDate"].Visible = false;
            if (CID >= 0)
            {
                string sCID = string.Format("{0}", CID);
                for (int i = 0; i < dgvCustomers.RowCount; i++)
                {
                    if (dgvCustomers.Rows[i].Cells["CID"].Value.ToString().Equals(sCID))
                    {
                        dgvCustomers.ClearSelection();
                        dgvCustomers.FirstDisplayedScrollingRowIndex = i;
                        dgvCustomers.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }

        public void selectOrders()
        {
            OrderInfo order = new OrderInfo();
            order.ONumber = txt_SelONumber.Text;
            dgvOrders.DataSource = OrderInfoManager.GetOrderInfoAll(order);
        }

        #region selectMethod
        private void 商品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage商品列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage商品列表;
            selectProduct();
        }
        private void 订单查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage订单列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage订单列表;
            selectOrders();
        }
        private void 客户查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage客户列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage客户列表;
            selectCustomers();
        }
        #endregion selectMethod

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

        private void 查询_Click(object sender, EventArgs e)
        {
            selectProduct();
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
            selectCustomers();
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
            if (attachment == null)
            {
                MessageBoxEx.Show(this, "请上传产品图片！");
                return;
            }
            ProductInfo pInfo = new ProductInfo();
            pInfo.PImageID = Guid.NewGuid();
            pInfo.PName = textBox_pName.Text.Trim();
            pInfo.PPrice = decimal.Parse(textBox_pPrice.Text.Trim());
            pInfo.PWeigth = decimal.Parse(textBox_pWeight.Text.Trim());
            pInfo.PSuppliter = textBox_pSuppliter.Text.Trim();
            pInfo.PNumber = textBox_pNumber.Text.Trim();
            pInfo.PRemark = textBox_pRemark.Text.Trim();
            int idx = ProductInfoManager.AddProductInfo(pInfo, attachment);
            if (idx > 0)
            {
                MessageBoxEx.Show(this, "添加成功！");
            }
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
                Image img = Image.FromFile(ofd.FileName);
                Bitmap newImg = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(newImg);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                g.Dispose();
                MemoryStream ms = new MemoryStream();
                newImg.Save(ms, ImageFormat.Jpeg);
                byte[] bs = ms.ToArray();

                attachment = new Attachment();
                attachment.Content = bs;
                attachment.Length = bs.Length;
                pictureBox_pImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void dgvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int PID = Convert.ToInt32(dgvProducts.CurrentRow.Cells["PID"].Value.ToString());
            Guid PImageID = new Guid(dgvProducts.CurrentRow.Cells["PImageID"].Value.ToString());
            EditProduct edit = new EditProduct(PID, PImageID);
            edit.mainForm = this;
            edit.ShowDialog(this);
        }

        private void dgvCustomers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CID = Convert.ToInt32(this.dgvCustomers.CurrentRow.Cells["CID"].Value.ToString());
            EditCustomer edit = new EditCustomer(CID);
            edit.mainForm = this;
            edit.ShowDialog(this);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            selectOrders();
        }
        
        private void txt_SelProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                selectProduct();
            }
        }
        private void txt_SelCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectCustomers();
            }
        }
        private void txt_SelOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectOrders();
            }
        }
    }
}
