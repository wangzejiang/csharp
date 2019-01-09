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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            // 窗体位于Windows最顶部
            this.TopMost = true;
            // 去除窗体边框
            this.FormBorderStyle = FormBorderStyle.None;//5+1+a+s+p+x
                                                        // 设置窗体最大化大小(除底部任务栏部分)
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            // 设置Windows窗口状态为最大化模式
            this.WindowState = FormWindowState.Maximized;

            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;



            label1.Location = new Point((this.Width - label1.Width) / 2, 20);
            label1.TextAlign = ContentAlignment.MiddleCenter;
           
        }
    }
}
