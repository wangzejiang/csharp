using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public class IForm : Form
    {
        protected OrderInfo order;
        protected CustomerInfo customer;
        protected IList<OrderProductInfo> products;
        protected UserInfo user;
        protected Attachment attachment;
        public decimal? getMinPrice(int? CID, int? PID, decimal? OpPriceX)
        {
            OrderProductInfo tmp = new OrderProductInfo();
            tmp.CID = CID;
            tmp.PID = PID;
            OrderProductInfo op = OrderProductInfoManager.GetOrderProductMinPrice(tmp);
            return op != null ? op.OpPriceX : OpPriceX;
        }
        protected void resetOrderProductInfo()
        {
            foreach (OrderProductInfo p in products)
            {
                p.priceCount = decimal.Round((decimal)(p.OpPrice * p.OpCount),2);
                p.priceXCount = decimal.Round((decimal)(p.OpPriceX * p.OpCount),2);
                p.weigthCount = decimal.Round((decimal)(p.OpWeigth * p.OpCount),2);
                p.priceZCount = decimal.Round((decimal)(p.priceXCount - p.priceCount),2);
            }
        }
        protected void resetSubOrders(DataGridView dgvSubOrders, int RowIndex)
        {
            var row = dgvSubOrders.Rows[RowIndex];

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
        protected void resetSubOrdersDataSource(DataGridView dgvSubOrders)
        {
            dgvSubOrders.DataSource = null;
            dgvSubOrders.DataSource = products;

            dgvSubOrders.Columns["OpImageBytes"].HeaderCell.Value = "图片";
            dgvSubOrders.Columns["OpName"].HeaderCell.Value = "名称";
            dgvSubOrders.Columns["OpSuppliter"].HeaderCell.Value = "供应商";
            dgvSubOrders.Columns["OpNumber"].HeaderCell.Value = "编号";
            dgvSubOrders.Columns["OpPrice"].HeaderCell.Value = "成本价";
            dgvSubOrders.Columns["OpWeigth"].HeaderCell.Value = "重量";
            dgvSubOrders.Columns["OpRemark"].HeaderCell.Value = "备注(*)";
            dgvSubOrders.Columns["OpPriceX"].HeaderCell.Value = "销售价(*)";  // 修改项
            dgvSubOrders.Columns["OpCount"].HeaderCell.Value = "数量(*)"; // 修改项
                                                                        // dgvSubOrders.Columns["OpPriceY"].HeaderCell.Value = "优惠金额"; // 修改项

            dgvSubOrders.Columns["priceCount"].HeaderCell.Value = "总成本";
            dgvSubOrders.Columns["priceXCount"].HeaderCell.Value = "总价";
            dgvSubOrders.Columns["priceZCount"].HeaderCell.Value = "总利润";
            dgvSubOrders.Columns["weigthCount"].HeaderCell.Value = "总重量";

            dgvSubOrders.Columns["PID"].Visible = false;
            dgvSubOrders.Columns["CID"].Visible = false;
            dgvSubOrders.Columns["OID"].Visible = false;
            dgvSubOrders.Columns["ONumber"].Visible = false;
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
            dgvSubOrders.Columns["priceCount"].ReadOnly = true;
            dgvSubOrders.Columns["priceXCount"].ReadOnly = true;
            dgvSubOrders.Columns["priceZCount"].ReadOnly = true;
            dgvSubOrders.Columns["weigthCount"].ReadOnly = true;
            //dgvSubOrders.Columns["OpRemark"].ReadOnly = true;
        }
        protected void AddOrderProductInfo(int? pID, int? Count)
        {

            foreach (OrderProductInfo exop in products)
            {
                if (exop.PID == pID)
                {
                    MessageBoxEx.Show(this, "商品已经存在!");
                    return;
                }
            }
            OrderProductInfo op = new OrderProductInfo();
            ProductInfo p = new ProductInfo();
            p.PID = pID;
            p = ProductInfoManager.GetProductInfo2(p);

            op.CID = customer.CID;
            op.OID = null;
            op.PID = pID;
            op.ONumber = order.ONumber;
            op.CreateDate = null;
            op.UpdateDate = null;
            op.OpCount = Count;
            op.OpID = pID;
            op.OpImageBytes = p.PImageBytes;
            op.OpImageID = p.PImageID;
            op.OpName = p.PName;
            op.OpNumber = p.PNumber;
            op.OpPrice = p.PPrice;
            op.OpPriceX = getMinPrice(op.CID, op.OpID, p.PPriceX);
            // op.OpPriceY = p.PPriceX - op.OpPriceX;
            op.OpRemark = p.PRemark;
            op.OpSuppliter = p.PSuppliter;
            op.OpWeigth = p.PWeigth;

            products.Add(op);
        }
        public virtual void addOrderProduct(int? pID, int? Count)
        {
            MessageBox.Show("Test");
        }
        public virtual void setCustomer(CustomerInfo customer)
        {
            MessageBox.Show("Test");
        }

        protected void selectCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomer sc = new SelectCustomer(this);
            sc.StartPosition = FormStartPosition.CenterParent;
            sc.ShowDialog(this);
        }
        protected void selectProduct_Click(object sender, EventArgs e)
        {
            if (customer.CID == null || customer.CID <= 0)
            {
                MessageBoxEx.Show(this, "请先选择客户!");
                return;
            }
            SelectProduct sp = new SelectProduct(this);
            sp.StartPosition = FormStartPosition.CenterParent;
            sp.ShowDialog(this);
        }
    }
}
