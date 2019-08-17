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
    public partial class SelectProduct : Form
    {
        private IForm mForm;
        public SelectProduct(IForm m)
        {
            mForm = m;
            InitializeComponent();
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            ProductInfo pinfo = new ProductInfo();
            pinfo.PName = txt_SelPName.Text;
            pinfo.PNumber = txt_SelPNumber.Text;
            pinfo.PSuppliter = txt_SelPSuppliter.Text;
            Common.selectProduct(dgvProducts, pinfo);
        }

        private void SelectProduct_Load(object sender, EventArgs e)
        {
            ProductInfo pinfo = new ProductInfo();
            pinfo.PName = txt_SelPName.Text;
            pinfo.PNumber = txt_SelPNumber.Text;
            pinfo.PSuppliter = txt_SelPSuppliter.Text;
            Common.selectProduct(dgvProducts, pinfo);
        }

        private void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int PID = Convert.ToInt32(dgvProducts.CurrentRow.Cells["PID"].Value.ToString());
            int Count = int.Parse(textBox1.Text);
            mForm.addOrderProduct(PID, Count);
            this.Close();
        }
    }
}
