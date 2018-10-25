using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 拆弹专家
{
    public class Utils
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("USER32.DLL")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);
        [DllImport("user32.DLL")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("kernel32.dll")]//打开一个已存在的进程对象,并返回进程的句柄
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int processId);
        [DllImport("kernel32.dll")]//为指定的进程分配内存地址:成功则返回分配内存的首地址
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll")]//从指定内存中读取字节集数据
        public static extern bool ReadProcessMemory(
                                            IntPtr hProcess, //被读取者的进程句柄
                                            IntPtr lpBaseAddress,//开始读取的内存地址
                                            IntPtr lpBuffer, //数据存储变量
                                            int nSize, //要写入多少字节
                                            ref uint vNumberOfBytesRead//读取长度
        );
        [DllImport("kernel32.dll")]//将数据写入内存中
        public static extern bool WriteProcessMemory(
                                            IntPtr hProcess,//由OpenProcess返回的进程句柄
                                            IntPtr lpBaseAddress, //要写的内存首地址,再写入之前,此函数将先检查目标地址是否可用,并能容纳待写入的数据
                                            IntPtr lpBuffer, //指向要写的数据的指针
                                            int nSize, //要写入的字节数
                                            ref uint vNumberOfBytesRead
        );
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);
        [DllImport("kernel32.dll")]//在其它进程中释放申请的虚拟内存空间
        public static extern bool VirtualFreeEx(
                                    IntPtr hProcess,//目标进程的句柄,该句柄必须拥有PROCESS_VM_OPERATION的权限
                                    IntPtr lpAddress,//指向要释放的虚拟内存空间首地址的指针
                                    uint dwSize,
                                    uint dwFreeType//释放类型
        );
        [DllImport("user32.dll")]//找出某个窗口的创建者(线程或进程),返回创建者的标志符
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int processId);
    }
}
