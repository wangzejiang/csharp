using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public partial class EditOrder : IForm
    {
        private int OID;
        public EditOrder(int OID)
        {
            this.OID = OID;
            InitializeComponent();
            this.button8.Click += new System.EventHandler(selectCustomer_Click);
            this.button7.Click += new System.EventHandler(selectProduct_Click);
        }
        public override void setCustomer(CustomerInfo _customer)
        {
            this.customer = _customer;
            txt_Order_CAddress.Text = customer.CAddress;
            txt_Order_CPhone.Text = customer.CPhone;
            txt_Order_CName.Text = customer.CName;
        }

        public override void addOrderProduct(int? pID, int? Count)
        {
            AddOrderProductInfo(pID, Count);
            resetOrderInfo();
            resetSubOrdersDataSource(dgvSubOrders);
        }
        private void EditOrder_Load(object sender, EventArgs e)
        {
            // load order
            OrderInfo tmp_order = new OrderInfo();
            tmp_order.OID = OID;
            order = OrderInfoManager.GetOrderInfo(tmp_order);
            txt_orderNumber.Text = order.ONumber;
            txt_OrderOtherPrice.Text = order.OtherPrice.ToString();
            txt_Order_PriceOK.Text = order.OPriceOK.ToString();
            txt_OrderRemark.Text = order.ORemark;
            txt_OrderRemark2.Text = order.ORemark2;
            dtp_OrderDate.Value = (DateTime)order.ODate;
            // load customer
            CustomerInfo tmpc = new CustomerInfo(order.CID,null,null, order.CName, order.CPhone, order.CAddress);
            setCustomer(tmpc);
            // load orderProducts
            OrderProductInfo op = new OrderProductInfo();
            op.OID = order.OID;
            products = OrderProductInfoManager.GetOrderProductInfoAll(op);
            
            this.resetOrderInfo();
            this.resetSubOrdersDataSource(dgvSubOrders);

            if(order.OStatus == 1) orderReadOnly(); 
        }

        private void orderReadOnly()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = false;
            }
            dgvSubOrders.Enabled = true;
            dgvSubOrders.ReadOnly = true;
        }

        private void resetOrderInfo()
        {
            resetOrderProductInfo();
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
            //order.OID = null;
            //order.OStatus = 0;
            order.ODate = dtp_OrderDate.Value;
            //order.CreateDate = null;
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
            OrderInfo old = new OrderInfo();
            old.OID = order.OID;
            int idx = OrderInfoManager.UpdateOrderInfo(order, old);
            if (idx > 0)
            {
                // del otherProducts
                OrderProductInfo del_op = new OrderProductInfo();
                del_op.OID = order.OID;
                OrderProductInfoManager.DeleteOrderProductInfo(del_op);
                // add otherProducts
                foreach (OrderProductInfo op in products)
                {
                    OrderProductInfoManager.AddOrderProductInfo(op);
                }
                MessageBoxEx.Show(this, "订单编辑成功！");
            }
        }
    }
}
