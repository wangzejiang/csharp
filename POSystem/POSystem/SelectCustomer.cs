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
    public partial class SelectCustomer : Form
    {
        private MainForm mForm;
        public SelectCustomer(MainForm m)
        {
            mForm = m;
            InitializeComponent();
        }
        private void selectCustomers()
        {
            CustomerInfo cinfo = new CustomerInfo();
            cinfo.CName = txt_SelCName.Text;
            cinfo.CPhone = txt_SelCPhone.Text;
            Common.selectCustomers(dgvCustomers, cinfo);
        }
        private void txt_SelCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectCustomers();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            selectCustomers();
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {
            CustomerInfo cinfo = new CustomerInfo();
            cinfo.CName = txt_SelCName.Text;
            cinfo.CPhone = txt_SelCPhone.Text;
            Common.selectCustomers(dgvCustomers, cinfo);
        }

        private void dgvCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int CID = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CID"].Value.ToString());
            string CName = dgvCustomers.CurrentRow.Cells["CName"].Value.ToString();
            string CPhone = dgvCustomers.CurrentRow.Cells["CPhone"].Value.ToString();
            string CAddress = dgvCustomers.CurrentRow.Cells["CAddress"].Value.ToString();
            mForm.setCustomer(CID, CName, CPhone, CAddress);
            this.Close();
        }
    }
}
