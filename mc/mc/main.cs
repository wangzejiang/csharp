using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mc
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        GlobalHook hook;

        private void main_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            btnInstallHook.Enabled = true;
            btnUnInstall.Enabled = false;
            //初始化钩子对象
            if (hook == null)
            {
                hook = new GlobalHook();
                hook.KeyDown += new KeyEventHandler(hook_KeyDown);
                hook.KeyPress += new KeyPressEventHandler(hook_KeyPress);
                hook.KeyUp += new KeyEventHandler(hook_KeyUp);
                hook.OnMouseActivity += new MouseEventHandler(hook_OnMouseActivity);
            }
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnUnInstall.Enabled == true)
            {
                hook.Stop();
            }
        }

        private void btnInstallHook_Click(object sender, EventArgs e)
        {
            if (btnInstallHook.Enabled == true)
            {
                bool r = hook.Start();
                if (r)
                {
                    btnInstallHook.Enabled = false;
                    btnUnInstall.Enabled = true;
                    MessageBox.Show("安装钩子成功!");
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("安装钩子失败!");
                }
            }
        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            if (btnUnInstall.Enabled == true)
            {
                hook.Stop();
                btnUnInstall.Enabled = false;
                btnInstallHook.Enabled = true;
                MessageBox.Show("卸载钩子成功!");
            }
        }


        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        void hook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            count = 0;
            lbMouseState.Text = "X:" + e.X + " Y:" + e.Y;
        }
        /// <summary>
        /// 键盘抬起
        /// </summary>
        void hook_KeyUp(object sender, KeyEventArgs e)
        {
            count = 0;
            lbKeyState.Text = "键盘抬起, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
        }
        /// <summary>
        /// 键盘输入
        /// </summary>
        void hook_KeyPress(object sender, KeyPressEventArgs e)
        {
            count = 0;
        }
        /// <summary>
        /// 键盘按下
        /// </summary>
        void hook_KeyDown(object sender, KeyEventArgs e)
        {
            count = 0;
            lbKeyState.Text = "键盘按下, " + e.KeyData.ToString() + " 键码:" + e.KeyValue;
        }

        private static int count = 0;
        private Form3 form = new Form3();
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            label1.Text = string.Format("{0}", count);
            if(count > 5)
            {
                if (form.IsDisposed)
                {
                    form = new Form3();
                }
                form.Show();
            }
        }
    }
}
