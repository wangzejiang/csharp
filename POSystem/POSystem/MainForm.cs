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
        //public LoginForm loginForm { get; set; }
        public MainForm(LoginForm _loginForm)
        {
            //this.loginForm = _loginForm;
            InitializeComponent();
        }
        public MainForm()
        {
            InitializeComponent();
        }

        #region addMethod
        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage新增商品.Parent = MainTabControl;
            MainTabControl.SelectedTab = tabPage新增商品;
        }
        private OrderInfo order;
        private IList<OrderProductInfo> products;
        private void 新订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = new OrderInfo();
            products = new List<OrderProductInfo>();
            dgvSubOrders.DataSource = null;
            tabPage新订单.Parent = MainTabControl;
            MainTabControl.SelectedTab = tabPage新订单;
        }
        private void 新增客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage新增客户.Parent = MainTabControl;
            MainTabControl.SelectedTab = tabPage新增客户;
        }
        #endregion addMethod

        private void button7_Click(object sender, EventArgs e)
        {
            SelectProduct sp = new SelectProduct(this);
            sp.ShowDialog(this);
        }
        internal void addOrderProduct(int? pID, int? Count)
        {
            OrderProductInfo op = new OrderProductInfo();
            ProductInfo p = new ProductInfo();
            p.PID = pID;
            p = ProductInfoManager.GetProductInfo2(p);
            op.CreateDate = null;
            op.UpdateDate = null;
            op.OpCount = Count;
            op.OpID = null;
            op.OpImageBytes = p.PImageBytes;
            op.OpImageID = p.PImageID;
            op.OpName = p.PName;
            op.OpNumber = p.PNumber;
            op.OpPrice = p.PPrice;
            op.OpPriceX = p.PPriceX;
            op.OpRemark = p.PRemark;
            op.OpSuppliter = p.PSuppliter;
            op.OpWeigth = p.PWeigth;

            products.Add(op);

            resetOrderProductInfo();
            resetOrderInfo();

            dgvSubOrders.DataSource = null;
            dgvSubOrders.DataSource = products;

            dgvSubOrders.Columns["OpImageBytes"].HeaderCell.Value = "图片";
            dgvSubOrders.Columns["OpName"].HeaderCell.Value = "名称";
            dgvSubOrders.Columns["OpSuppliter"].HeaderCell.Value = "供应商";
            dgvSubOrders.Columns["OpNumber"].HeaderCell.Value = "编号";
            dgvSubOrders.Columns["OpRemark"].HeaderCell.Value = "备注";
            dgvSubOrders.Columns["OpPrice"].HeaderCell.Value = "成本价";
            dgvSubOrders.Columns["OpWeigth"].HeaderCell.Value = "重量";
            dgvSubOrders.Columns["OpPriceX"].HeaderCell.Value = "销售价";  // 修改项
            dgvSubOrders.Columns["OpCount"].HeaderCell.Value = "数量"; // 修改项

            dgvSubOrders.Columns["priceCount"].HeaderCell.Value = "总成本";
            dgvSubOrders.Columns["priceXCount"].HeaderCell.Value = "总价";
            dgvSubOrders.Columns["priceZCount"].HeaderCell.Value = "总利润";
            dgvSubOrders.Columns["weigthCount"].HeaderCell.Value = "总重量";

            dgvSubOrders.Columns["OpID"].Visible = false;
            dgvSubOrders.Columns["OpImageID"].Visible = false;
            dgvSubOrders.Columns["CreateDate"].Visible = false;
            dgvSubOrders.Columns["UpdateDate"].Visible = false;

            dgvSubOrders.Columns["OpImageBytes"].ReadOnly = true;
            dgvSubOrders.Columns["OpName"].ReadOnly = true;
            dgvSubOrders.Columns["OpNumber"].ReadOnly = true;
            dgvSubOrders.Columns["OpSuppliter"].ReadOnly = true;
            dgvSubOrders.Columns["OpPrice"].ReadOnly = true;
            dgvSubOrders.Columns["OpWeigth"].ReadOnly = true;
            //dgvSubOrders.Columns["OpRemark"].ReadOnly = true;
        }
        private void dgvSubOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 数据刷新
            resetOrderProductInfo();
            resetOrderInfo();
            //  界面刷新
            var row = dgvSubOrders.Rows[e.RowIndex];

            decimal OpCount = decimal.Parse(row.Cells["OpCount"].Value.ToString());
            decimal OpPrice = decimal.Parse(row.Cells["OpPrice"].Value.ToString());
            decimal OpPriceX = decimal.Parse(row.Cells["OpPriceX"].Value.ToString());
            decimal OpWeigth = decimal.Parse(row.Cells["OpWeigth"].Value.ToString());

            row.Cells["priceCount"].Value = OpPrice * OpCount;
            row.Cells["priceXCount"].Value = OpPriceX * OpCount;
            row.Cells["priceZCount"].Value = (OpPriceX - OpPrice) * OpCount;
            row.Cells["weigthCount"].Value = OpWeigth * OpCount;

            dgvSubOrders.Refresh();
        }
        internal void resetOrderProductInfo()
        {
            foreach (OrderProductInfo p in products)
            {
                p.priceCount = p.OpPrice * p.OpCount;
                p.priceXCount = p.OpPriceX * p.OpCount;
                p.weigthCount = p.OpWeigth * p.OpCount;
                p.priceZCount = p.priceXCount - p.priceCount;
            }
        }
        internal void resetOrderInfo()
        {
            decimal? price = 0, pricex = 0, pricez = 0, weigth = 0;
            foreach (OrderProductInfo p in products)
            {
                price += p.priceCount;
                pricex += p.priceXCount;
                pricez += p.priceZCount;
                weigth += p.weigthCount;
            }
            txt_OrderPriceCount.Text = price.ToString();
            txt_OrderPriceXCount.Text = pricex.ToString();
            txt_OrderPriceZCount.Text = pricez.ToString();
            txt_WeigthCount.Text = weigth.ToString();
        }
        internal void setCustomer(int? cID, string cName, string cPhone, string cAddress)
        {
            txt_Order_CAddress.Text = cAddress;
            txt_Order_CPhone.Text = cPhone;
            txt_Order_CName.Text = cName;
        }
        public void selectProduct(int? PID = -1)
        {
            ProductInfo pinfo = new ProductInfo();
            pinfo.PName = txt_SelPName.Text;
            pinfo.PNumber = txt_SelPNumber.Text;
            pinfo.PSuppliter = txt_SelPSuppliter.Text;
            Common.selectProduct(dgvProducts, pinfo, PID);
        }
        public void selectCustomers(int? CID = -1)
        {
            CustomerInfo cinfo = new CustomerInfo();
            cinfo.CName = txt_SelCName.Text;
            cinfo.CPhone = txt_SelCPhone.Text;
            Common.selectCustomers(dgvCustomers, cinfo, CID);
        }

        public void selectOrders()
        {
            OrderInfo order = new OrderInfo();
            order.ONumber = txt_SelONumber.Text;
            order.CName = txt_SelOCName.Text;
            dgvOrders.DataSource = OrderInfoManager.GetOrderInfoAll(order);
            dgvOrders.Columns["OWeigth"].HeaderCell.Value = "总重量";
            dgvOrders.Columns["ODate"].HeaderCell.Value = "订单时间";
            dgvOrders.Columns["OPriceX"].HeaderCell.Value = "总售价";
            dgvOrders.Columns["OPrice"].HeaderCell.Value = "总成本";
            dgvOrders.Columns["OPriceZ"].HeaderCell.Value = "总利润";
            dgvOrders.Columns["CName"].HeaderCell.Value = "客户名称";
            dgvOrders.Columns["CPhone"].HeaderCell.Value = "联系方式";
            dgvOrders.Columns["CAddress"].HeaderCell.Value = "联系地址";
            dgvOrders.Columns["UName"].HeaderCell.Value = "创建员";
            dgvOrders.Columns["ONumber"].HeaderCell.Value = "订单编号";
            dgvOrders.Columns["ORemark"].Visible = false;
            dgvOrders.Columns["ORemark2"].Visible = false;
            dgvOrders.Columns["CreateDate"].Visible = false;
            dgvOrders.Columns["UpdateDate"].Visible = false;
            dgvOrders.Columns["OID"].Visible = false;
            dgvOrders.Columns["OStatus"].Visible = false;
        }

        #region selectMethod
        private void 商品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage商品列表.Parent = this.MainTabControl;
            MainTabControl.SelectedTab = this.tabPage商品列表;
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

        private void button8_Click(object sender, EventArgs e)
        {
            SelectCustomer sc = new SelectCustomer(this);
            sc.ShowDialog(this);
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
            if (e.KeyCode == Keys.Enter)
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
