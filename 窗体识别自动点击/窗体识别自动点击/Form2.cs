using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using System.Threading;

namespace 窗体识别自动点击
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);

        const int WM_GETTEXT = 0x000D;
        const int WM_SETTEXT = 0x000C;
        const int WM_CLICK = 0x00F5;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        public enum WindowSearch
        {
            GW_HWNDFIRST = 0, //同级别第一个
            GW_HWNDLAST = 1, //同级别最后一个
            GW_HWNDNEXT = 2, //同级别下一个
            GW_HWNDPREV = 3, //同级别上一个
            GW_OWNER = 4, //属主窗口
            GW_CHILD = 5 //子窗口}获取与指定窗口具有指定关系的窗口的句柄 
        }
        public IntPtr isTextPtr(IntPtr hwd, string str, int flag)
        {
            IntPtr retHwh = IntPtr.Zero;
            StringBuilder sb = new StringBuilder(256);
            GetWindowTextW(hwd, sb, sb.Capacity);
            if (string.IsNullOrEmpty(sb.ToString()))
            {
                return retHwh;
            }
            if (flag == 1 && sb.ToString().IndexOf(str) > -1)
            {
                retHwh = hwd;
                Console.WriteLine(sb.ToString());
                label3.Text = sb.ToString();
            }
            if (flag == 2 && sb.ToString().Equals(str))
            {
                retHwh = hwd;
            }
            return retHwh;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            test();
        }

        public void test()
        {
            string[] words = textBox1.Text.Split(',');
            label1.Text = "";
            label2.Text = "";

            Point defPnt = new Point();
            GetCursorPos(ref defPnt);
            label1.Text = string.Format("{0},{1}", defPnt.X.ToString(), defPnt.Y.ToString());
            IntPtr ParenthWnd = FindWindow(null, "网店管家(云端版)");
            if (!ParenthWnd.Equals(IntPtr.Zero))
            {
                IntPtr tmp = IntPtr.Zero;
                IntPtr ok = IntPtr.Zero;
                IntPtr text = IntPtr.Zero;
                IntPtr speak = IntPtr.Zero;
                // 获取子控件
                IntPtr hwd = GetWindow(ParenthWnd, (int)WindowSearch.GW_CHILD);
                do
                {
                    tmp = isTextPtr(hwd, "确定", 2);
                    if (tmp != IntPtr.Zero) ok = tmp;
                    foreach (var word in words)
                    {
                        tmp = isTextPtr(hwd, word, 1);
                        if (tmp != IntPtr.Zero)
                        {
                            text = tmp;
                            break;
                        };
                    }
                    tmp = isTextPtr(hwd, textBox2.Text, 1);
                    if (tmp != IntPtr.Zero) speak = tmp;
                    hwd = GetWindow(hwd, (int)WindowSearch.GW_HWNDNEXT);
                } while (hwd != IntPtr.Zero);
                if (ok != IntPtr.Zero && text != IntPtr.Zero)
                {
                    SetForegroundWindow(ParenthWnd);
                    click(ok);
                }
                if (speak != IntPtr.Zero)
                {
                    SetForegroundWindow(ParenthWnd);
                    StringBuilder sb = new StringBuilder(256);
                    GetWindowTextW(speak, sb, sb.Capacity);
                    SendMessage(ParenthWnd, 12, IntPtr.Zero, "退款提示框");
                    Thread thread = new Thread(() =>
                    {
                        SpVoice voice = new SpVoice();
                        voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(0);
                        //voice.Volume = 100;
                        voice.Speak(sb.ToString(), SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
                        thread = null;
                    });
                    thread.Start();
                }
            }
        }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        [DllImport("User32")]
        public extern static int ShowCursor(bool bShow);

        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        public void click(IntPtr hWnd)
        {
            RECT windowRect = new RECT();
            GetWindowRect(hWnd, ref windowRect);
            int x = windowRect.left + 10;
            int y = windowRect.top + 10;
            label2.Text = string.Format("{0},{1}", x, y);
            ShowCursor(false);
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, IntPtr.Zero);
            ShowCursor(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("测试订单2已完成", "网店管家(云端版)");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"xxxxxxxxxxx\"存在同名未合并的订单，确定要发货吗？", "网店管家(云端版)", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("测试退款了", "网店管家(云端版)");
            //new Form1().Show();
        }
    }
}
