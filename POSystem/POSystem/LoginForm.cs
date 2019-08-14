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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();
            user.UName = textBox1.Text.Trim();
            user.UPassword = textBox2.Text.Trim();
            bool flag = UserInfoManager.GetUserInfoBool(user);
            if (flag)
            {
                MainForm mForm = new MainForm(this);
                mForm.Show(this);
                this.Hide();
            }
            else
            {
                MessageBoxEx.Show(this,"用户名或密码错误!");
            }
        }
    }
}
