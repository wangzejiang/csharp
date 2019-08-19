using Aspose.Cells;
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
    public partial class MainForm : IForm
    {
        public MainForm(UserInfo user)
        {
            this.user = user;
            InitializeComponent();
            this.button8.Click += new System.EventHandler(selectCustomer_Click);
            this.button7.Click += new System.EventHandler(selectProduct_Click);
        }
        private void newOrder()
        {
            // new customer
            CustomerInfo tmp_customer = new CustomerInfo();
            this.setCustomer(tmp_customer);
            // new orderProduct
            products = new List<OrderProductInfo>();
            dgvSubOrders.DataSource = null;
            // new order
            order = new OrderInfo();
            order.ONumber = string.Format("PO{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), new Random().Next(100, 999));
            txt_orderNumber.Text = order.ONumber;
            txt_OrderOtherPrice.Text = "";
            txt_Order_PriceOK.Text = "";
            txt_OrderRemark.Text = "";
            txt_OrderRemark2.Text = "";
            dtp_OrderDate.Value = DateTime.Now;
            resetOrderInfo();
        }
        internal void resetOrderInfo()
        {
            resetOrderProductInfo();  // 计算订单产品价格
            // 计算订单总价格
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
        #region addMethod
        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage新增商品.Parent = MainTabControl;
            MainTabControl.SelectedTab = tabPage新增商品;
        }
        private void 新订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newOrder();
            tabPage新订单.Parent = MainTabControl;
            MainTabControl.SelectedTab = tabPage新订单;
        }
        private void 新增客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage新增客户.Parent = MainTabControl;
            MainTabControl.SelectedTab = tabPage新增客户;
        }
        #endregion addMethod


        public override void addOrderProduct(int? pID, int? Count)
        {
            AddOrderProductInfo(pID, Count);
            resetOrderInfo();
            resetSubOrdersDataSource(dgvSubOrders);
        }


        private void dgvSubOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 数据刷新
            resetOrderInfo();
            //  界面刷新
            resetSubOrders(dgvSubOrders, e.RowIndex);
        }

        public override void setCustomer(CustomerInfo _customer)
        {
            this.customer = _customer;
            txt_Order_CAddress.Text = customer.CAddress;
            txt_Order_CPhone.Text = customer.CPhone;
            txt_Order_CName.Text = customer.CName;
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
            //button11.Visible = !ck_OStatus.Checked;
            OrderInfo order = new OrderInfo();
            order.ONumber = txt_SelONumber.Text;
            order.CName = txt_SelOCName.Text;
            order.OStatus = ck_OStatus.Checked ? 1 : 0;
            dgvOrders.DataSource = OrderInfoManager.GetOrderInfoAll(order);
            dgvOrders.Columns["OWeigth"].HeaderCell.Value = "总重量";
            dgvOrders.Columns["ODate"].HeaderCell.Value = "订单时间";
            dgvOrders.Columns["OPriceX"].HeaderCell.Value = "总售价";
            dgvOrders.Columns["OPrice"].HeaderCell.Value = "总成本";
            dgvOrders.Columns["OPriceZ"].HeaderCell.Value = "总利润";
            dgvOrders.Columns["OPriceOK"].HeaderCell.Value = "实际金额";
            dgvOrders.Columns["CName"].HeaderCell.Value = "客户名称";
            dgvOrders.Columns["CPhone"].HeaderCell.Value = "联系方式";
            dgvOrders.Columns["CAddress"].HeaderCell.Value = "地址";
            dgvOrders.Columns["UName"].HeaderCell.Value = "操作人";
            dgvOrders.Columns["ONumber"].HeaderCell.Value = "订单编号";
            dgvOrders.Columns["ORemark"].HeaderCell.Value = "备注";
            dgvOrders.Columns["ORemark2"].HeaderCell.Value = "内部备注";
            dgvOrders.Columns["OtherPrice"].HeaderCell.Value = "其他费用";
            //#if RELEASE
            //dgvOrders.Columns["ORemark"].Visible = false;
            //dgvOrders.Columns["ORemark2"].Visible = false;
            dgvOrders.Columns["CreateDate"].Visible = false;
            dgvOrders.Columns["UpdateDate"].Visible = false;
            dgvOrders.Columns["OID"].Visible = false;
            dgvOrders.Columns["CID"].Visible = false;
            dgvOrders.Columns["OStatus"].Visible = false;
            
            //#endif
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
            ck_OStatus.Checked = true;
            selectOrders();
        }
        private void 未打印订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage订单列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage订单列表;
            ck_OStatus.Checked = false;
            selectOrders();
        }
        private void 客户查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabPage客户列表.Parent = this.MainTabControl;
            this.MainTabControl.SelectedTab = this.tabPage客户列表;
            selectCustomers();
        }
        #endregion selectMethod

        private void MainTabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainTabControl.SelectedTab.Text.Equals(this.tabPage欢迎页.Text)) return;
            MainTabControl.SelectedTab.Parent = null;
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            selectProduct();
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
            if (CustomerInfoManager.GetCustomerInfoBool(cInfo))
            {
                MessageBoxEx.Show(this, "客户已经存在！");
                return;
            }
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
            pInfo.PSuppliter = textBox_pSuppliter.Text.Trim();
            pInfo.PNumber = textBox_pNumber.Text.Trim();
            if (ProductInfoManager.GetProductInfoBool(pInfo))
            {
                MessageBoxEx.Show(this, "产品已存在！");
                return;
            }
            pInfo.PName = textBox_pName.Text.Trim();
            pInfo.PImageID = Guid.NewGuid();
            pInfo.PPrice = decimal.Parse(textBox_pPrice.Text.Trim());
            pInfo.PPriceX = decimal.Parse(textBox_pPriceX.Text.Trim());
            pInfo.PWeigth = decimal.Parse(textBox_pWeight.Text.Trim());
            
            pInfo.PRemark = textBox_pRemark.Text.Trim();
            int idx = ProductInfoManager.AddProductInfo(pInfo, attachment);
            if (idx > 0)
            {
                MessageBoxEx.Show(this, "添加成功！");
            }
        }
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
            EditProduct edit = new EditProduct(this, PID, PImageID);
            edit.StartPosition = FormStartPosition.CenterParent;
            edit.ShowDialog(this);
        }

        private void dgvCustomers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CID = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CID"].Value.ToString());
            EditCustomer edit = new EditCustomer(CID);
            edit.mainForm = this;
            edit.StartPosition = FormStartPosition.CenterParent;
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (order.CID <= 0)
            {
                return;
            }
            if (products.Count <= 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(txt_Order_PriceOK.Text))
            {
                txt_Order_PriceOK.Text = txt_OrderPriceXCount.Text;
            }
            if (string.IsNullOrEmpty(txt_OrderOtherPrice.Text))
            {
                txt_OrderOtherPrice.Text = "0";
            }
            resetOrderInfo();
            order.OID = null;
            order.OStatus = 0;
            order.ODate = dtp_OrderDate.Value;
            order.CreateDate = null;
            order.UpdateDate = null;
            order.OWeigth = decimal.Parse(txt_WeigthCount.Text);
            order.OPrice = decimal.Parse(txt_OrderPriceCount.Text);
            order.OPriceX = decimal.Parse(txt_OrderPriceXCount.Text);
            order.OPriceZ = decimal.Parse(txt_OrderPriceZCount.Text);
            order.OPriceOK = decimal.Parse(txt_Order_PriceOK.Text);
            order.OtherPrice = decimal.Parse(txt_OrderOtherPrice.Text);
            order.UName = user != null ? user.UName : "system";
            // order.ONumber = 已经生成
            order.CID = customer.CID;
            order.CName = txt_Order_CName.Text;
            order.CPhone = txt_Order_CPhone.Text;
            order.CAddress = txt_Order_CAddress.Text;
            order.ORemark = txt_OrderRemark.Text;
            order.ORemark2 = txt_OrderRemark2.Text;
            int idx = OrderInfoManager.AddOrderInfo(order);
            if (idx > 0)
            {
                OrderInfo tmp = new OrderInfo();
                tmp.ONumber = order.ONumber;
                tmp = OrderInfoManager.GetOrderInfo(tmp);
                order.OID = tmp.OID;
                foreach (OrderProductInfo op in products)
                {
                    op.OID = order.OID;
                    OrderProductInfoManager.AddOrderProductInfo(op);
                }
                MessageBoxEx.Show(this, "订单创建成功！");
                newOrder();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (products.Count <= 0)
            {
                return;
            }
            int OpID = Convert.ToInt32(dgvSubOrders.CurrentRow.Cells["OpID"].Value.ToString());
            OrderProductInfo tmp = null;
            foreach (OrderProductInfo op in products)
            {
                if (op.OpID == OpID)
                {
                    tmp = op;
                    break;
                }
            }
            if (tmp != null)
            {
                products.Remove(tmp);
            }
            resetOrderInfo();
            resetSubOrdersDataSource(dgvSubOrders);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var tabpages = this.MainTabControl.TabPages;
            foreach (TabPage page in tabpages)
            {
                page.Parent = null;
            }
            this.tabPage欢迎页.Parent = this.MainTabControl;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    新订单ToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F4:
                    新增商品ToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F5:
                    新增客户ToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F6:
                    订单查询ToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int OID = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OID"].Value.ToString());
            EditOrder edit = new EditOrder(OID);
            edit.StartPosition = FormStartPosition.CenterParent;
            edit.ShowDialog(this);
        }

        private void ck_OStatus_CheckedChanged(object sender, EventArgs e)
        {
            //button11.Visible = !ck_OStatus.Checked;
            //selectOrders();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                if (dgvOrders.Rows.Count == 0) return;
                dgvOrders.Rows[0].Selected = true;
                dgvOrders.CurrentCell = dgvOrders.Rows[0].Cells["ONUMBER"];
            }
            int OID = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OID"].Value.ToString());
            PrinterForm printer = new PrinterForm(OID);
            printer.StartPosition = FormStartPosition.CenterParent;
            printer.ShowDialog(this);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
