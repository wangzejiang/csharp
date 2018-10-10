using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体识别自动点击
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("USER32.DLL")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);

        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }
        public WindowInfo[] GetAllDesktopWindows()
        {
            //用来保存窗口对象 列表
            List<WindowInfo> wndList = new List<WindowInfo>();

            //enum all desktop windows 
            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);

                //get hwnd 
                wnd.hWnd = hWnd;

                //get window name  
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();

                //get window class 
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();

                //add it into list 
                wndList.Add(wnd);
                return true;
            }, 0);
            return wndList.ToArray();
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

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 5 * 1000;
            timer1.Start();
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);
        [DllImport("user32.dll ")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public void test()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            WindowInfo[] wins = GetAllDesktopWindows();
            foreach (var win in wins)
            {
                if (win.szWindowName.StartsWith("网店管家(云端版)"))
                {
                    IntPtr tmp = IntPtr.Zero;
                    IntPtr ok = IntPtr.Zero;
                    IntPtr text = IntPtr.Zero;
                    // 获取子控件
                    IntPtr hwd = GetWindow(win.hWnd, (int)WindowSearch.GW_CHILD);
                    do
                    {
                        tmp = isTextPtr(hwd, "确定");
                        if (tmp != IntPtr.Zero) ok = tmp;
                        tmp = isTextPtr(hwd, "订单");
                        if (tmp != IntPtr.Zero) text = tmp;
                        hwd = GetWindow(hwd, (int)WindowSearch.GW_HWNDNEXT);
                    } while (hwd != IntPtr.Zero);
                    if (ok != IntPtr.Zero && text != IntPtr.Zero)
                    {
                        pictureBox1.Image = CaptureWindow(ok);
                        pictureBox2.Image = CaptureWindow(text);
                        SetForegroundWindow(win.hWnd);
                        Thread.Sleep(1000);
                        //SendKeys.SendWait("{Enter}");
                        //SendKeys.Send("{BREAK}");
                        //SendKeys.Send("{TAB}");
                        //click(ok);
                        //SendKeys.Flush();
                        //SendMessage(win.hWnd, 256, 0xD, 0);
                    }
                }
            }
        }

        public void click(IntPtr hWnd)
        {
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(hWnd, ref windowRect);
            int x = windowRect.left;
            int y = windowRect.top;
            Console.WriteLine("{0},{1}", x, y);
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, IntPtr.Zero);
        }
        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        public IntPtr isTextPtr(IntPtr hwd, string str)
        {
            StringBuilder sb = new StringBuilder(256);
            GetWindowTextW(hwd, sb, sb.Capacity);
            if (sb.ToString().IndexOf(str) > -1)
            {
                return hwd;
            }
            else
            {
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// 指定窗口截图
        /// </summary>
        /// <param name="handle">窗口句柄. (在windows应用程序中, 从Handle属性获得)</param>
        /// <returns></returns>
        public Bitmap CaptureWindow(IntPtr handle)
        {
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int i = 0;
            windowRect.left += i;
            windowRect.right -= i;
            windowRect.top += i;
            windowRect.bottom -= i;
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            GDI32.SelectObject(hdcDest, hOld);
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            Bitmap img = Image.FromHbitmap(hBitmap);
            GDI32.DeleteObject(hBitmap);
            return img;
        }
        /// <summary>
        /// 辅助类 定义 Gdi32 API 函数
        /// </summary>
        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020;
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// 辅助类 定义User32 API函数
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("测试订单1", "网店管家(云端版)", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            test();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("测试订单2", "网店管家(云端版)");
        }
    }
}
