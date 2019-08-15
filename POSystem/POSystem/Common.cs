using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public class Common
    {
        public static void selectProduct(DataGridView dgvProducts, ProductInfo pinfo, int? PID = -1)
        {
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.DataSource = ProductInfoManager.GetProductInfoAll2(pinfo);
            dgvProducts.Columns["pNumber"].HeaderCell.Value = "编号";
            dgvProducts.Columns["pName"].HeaderCell.Value = "名称";
            dgvProducts.Columns["PWeigth"].HeaderCell.Value = "重量";
            dgvProducts.Columns["PSuppliter"].HeaderCell.Value = "供应商";
            dgvProducts.Columns["PPrice"].HeaderCell.Value = "成本价";
            dgvProducts.Columns["PPriceX"].HeaderCell.Value = "销售价";
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

        public static void selectCustomers(DataGridView dgvCustomers, CustomerInfo cinfo, int? CID = -1)
        {
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

    }
}
