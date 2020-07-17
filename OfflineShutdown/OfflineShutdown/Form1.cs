using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OfflineShutdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Ping ping = new Ping();
        private const int max = 60;
        private static int number = max;
        private const int interval = 5000;
        private string NDDR = "192.168.0.220";
        private string RADDR = "192.168.0.1";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            string startup = Application.ExecutablePath;       //取得程序路径  
            int pp = startup.LastIndexOf("\\");
            startup = startup.Substring(0, pp);
            string icon = startup + "\\favicon.ico";
            //3.一定为notifyIcon1其设置图标，否则无法显示在通知栏。或者在其属性中设置
            notifyIcon1.Icon = new Icon(icon);
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "断网检查器";
            timer1.Interval = interval;
            timer1.Start();
        }

        // 这个结构体将会传递给API。使用StructLayout  
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        // 导入的方法必须是static extern的，并且没有方法体。调用这些方法就相当于调用Windows API。  
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);


        // 以下定义了在调用WinAPI时需要的常数。这些常数通常可以从Platform SDK的包含文件（头文件）中找到  
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int EWX_SHUTDOWN = 0x00000001;
        //internal const int EWX_LOGOFF = 0x00000000;  
        //internal const int EWX_REBOOT = 0x00000002;  
        //internal const int EWX_FORCE = 0x00000004;  
        //internal const int EWX_POWEROFF = 0x00000008;  
        //internal const int EWX_FORCEIFHUNG = 0x00000010;  


        // 通过调用WinAPI实现关机，主要代码再最后一行ExitWindowsEx，这调用了同名的WinAPI，正好是关机用的。  
        private static void DoExitWin(int flg)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(flg, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IPStatus.Success == ping.Send(NDDR).Status)
            {
                notifyIcon1.Text = "NAS网络正常!";
                return;
            }
            if (IPStatus.Success== ping.Send(RADDR).Status)
            {
                notifyIcon1.Text = "路由器正常!";
                return;
            }
            number--;
            if (number + 1 >= max)
            {
                DialogResult dr = MessageBox.Show(@"确定要关机吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    number = 3;
                }
                else
                {
                    Application.Exit();
                }
            }
            if (number <= 0)
            {
                notifyIcon1.Text = "关机";
                DoExitWin(EWX_SHUTDOWN);
            }
            else
            {
                notifyIcon1.Text = "等待关机:" + number;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(notifyIcon1.Text);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
