using POSystem;
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
    public partial class EditCustomer : Form
    {
        private CustomerInfo oldcustomerInfo = new CustomerInfo();
        private CustomerInfo updateCustomerInfo = new CustomerInfo();
        internal MainForm mainForm;

        public EditCustomer(int CID)
        {
            oldcustomerInfo.CID = CID;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateCustomerInfo.CPhone = textBox_cPhone.Text;
            updateCustomerInfo.CName = textBox_cName.Text;
            updateCustomerInfo.CAddress = textBox_cAddress.Text;
            int idx = CustomerInfoManager.UpdateCustomerInfo(updateCustomerInfo, oldcustomerInfo);
            if (idx > 0)
            {
                mainForm.selectCustomers(oldcustomerInfo.CID);
                MessageBoxEx.Show(this, "更新成功!");
            }else
            {
                MessageBoxEx.Show(this,"更新失败!");
            }
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            updateCustomerInfo = CustomerInfoManager.GetCustomerInfo(oldcustomerInfo);
            textBox_cPhone.Text = updateCustomerInfo.CPhone;
            textBox_cName.Text = updateCustomerInfo.CName;
            textBox_cAddress.Text = updateCustomerInfo.CAddress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
