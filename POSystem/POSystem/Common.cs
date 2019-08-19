using Aspose.Cells;
using Aspose.Cells.Rendering;
using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public class Common
    {
        public static MemoryStream moImage(MemoryStream imageByte, int Margin)
        {
            Image Img = Image.FromStream(imageByte);
            //获取图片宽高
            int Width = Img.Width;
            int Height = Img.Height;
            //获取图片水平和垂直的分辨率
            float dpiX = Img.HorizontalResolution;
            float dpiY = Img.VerticalResolution;
            //创建一个位图文件
            Bitmap bitmap = new Bitmap(Width + Margin * 2, Height + Margin * 2);
            bitmap.SetResolution(dpiX, dpiY);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Black);
            //向矩形框内填充Img
            g.DrawImage(Img, Margin, Margin, Width, Height);
            //返回位图文件
            g.Dispose();
            GC.Collect();
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            return ms;
        }
        public static Worksheet getPrintWorkbook(int OID)
        {
            OrderInfo order = new OrderInfo();
            order.OID = OID;
            order = OrderInfoManager.GetOrderInfo(order);
            OrderProductInfo op = new OrderProductInfo();
            op.OID = order.OID;
            IList<OrderProductInfo> products = OrderProductInfoManager.GetOrderProductInfoAll(op);
            //txt_orderNumber.Text = order.ONumber;
            //txt_OrderOtherPrice.Text = order.OtherPrice.ToString();
            //txt_Order_PriceOK.Text = order.OPriceOK.ToString();
            //txt_OrderRemark.Text = order.ORemark;
            //txt_OrderRemark2.Text = order.ORemark2;
            //dtp_OrderDate.Value = (DateTime)order.ODate;
            CustomerInfo customer = new CustomerInfo(order.CID, null, null, order.CName, order.CPhone, order.CAddress);
            Workbook wb = new Workbook("template.xlsx");
            Worksheet ws = wb.Worksheets[0];
            Cells c = ws.Cells;
            c[1, 2].PutValue(order.ONumber);
            c[2, 2].PutValue(customer.CName);
            c[3, 2].PutValue(customer.CAddress);
            c[1, 7].PutValue(((DateTime)order.ODate).ToString("yyyy-MM-dd"));
            c[2, 7].PutValue(customer.CPhone);
            ws.Cells.SetColumnWidthPixel(1, 100);
            int row = products.Count;
            decimal? price = 0, count = 0, weight = 0;
            for (int i = 0; i < products.Count; i++)
            {
                
                int r = i + 6;
                ws.Cells.InsertRow(r);
                ws.Cells.SetRowHeightPixel(r, 100);
                OrderProductInfo p = products[i];
                c[r, 0].PutValue(i+1);
                ws.Pictures.Add(r, 1, r + 1, 2, moImage(new MemoryStream(p.OpImageBytes), 1));
                int col = 2;
                c[r, col++].PutValue(p.OpSuppliter);
                c[r, col++].PutValue(p.OpName);
                c[r, col++].PutValue(p.OpNumber);
                c[r, col++].PutValue(p.OpWeigth);
                c[r, col++].PutValue(p.OpPriceX); // 单价
                c[r, col++].PutValue(p.OpCount);
                c[r, col++].PutValue(p.OpPriceX * p.OpCount);
                c[r, col++].PutValue(p.OpWeigth * p.OpCount);
                count += p.OpCount;
                price += p.OpPriceX * p.OpCount;
                weight += p.OpWeigth * p.OpCount;
            }
            c[row + 7, 2].PutValue(order.ORemark);

            c[row + 7 + 0, 6].PutValue(count);
            c[row + 7 + 1, 6].PutValue(weight);
            c[row + 7 + 2, 6].PutValue(price);
            c[row + 7 + 3, 6].PutValue(order.OPriceOK);
            c[row + 7 + 4, 6].PutValue(order.OtherPrice);
            c[row + 7 + 5, 6].PutValue(order.OPriceOK + order.OtherPrice);
            //print(ws);
            wb.Save("1.xlsx");
            return ws;
        }
        

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
