using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拆弹专家
{
    public partial class Form1 : ConstClass
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hwd = Utils.FindWindow(null, "网店管家云端版 - [订单审核]");
            if (hwd.Equals(IntPtr.Zero)) return;
            hwd = find(hwd, "MDIClient.TForm_TradeCHK.TPanel:2.TPanel.TListView"); //MDIClient.TForm_TradeCHK.TPanel:2.TPanel.TListView.SysHeader32
            int rows = 0;
            int cols = 0;
            getRowsCols(hwd, out rows, out cols);
            //MessageBox.Show(string.Format("{0}:{1}", rows, cols));
            int processId;
            Utils.GetWindowThreadProcessId(hwd, out processId);
            IntPtr process = Utils.OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, processId); //打开并插入进程
            IntPtr pointer = Utils.VirtualAllocEx(process, IntPtr.Zero, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE); //申请代码的内存区,返回申请到的虚拟内存首地址

            byte[] vBuffer = new byte[256];
            LVITEM[] vItem = new LVITEM[1];
            vItem[0].mask = LVIF_TEXT;
            vItem[0].iItem = 0;
            vItem[0].iSubItem = 0;
            vItem[0].cchTextMax = 256;
            vItem[0].pszText = pointer;

            uint vNumberOfBytesRead = 0;
            Utils.WriteProcessMemory(process, pointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(LVITEM)), ref vNumberOfBytesRead);
            Utils.SendMessage(hwd, LVM_GETITEMCOUNT, 0, (int)pointer); 
            Utils.ReadProcessMemory(process, pointer + Marshal.SizeOf(typeof(LVITEM)), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, ref vNumberOfBytesRead);

            foreach (byte item in vBuffer)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Utils.VirtualFreeEx(process, pointer, 0, MEM_RELEASE);//在其它进程中释放申请的虚拟内存空间,MEM_RELEASE方式很彻底,完全回收
            Utils.CloseHandle(process);//关闭打开的进程对象
            //MessageBox.Show(vText);
        }

        private struct LVITEM  //结构体
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int lParam;
            public int iIndent;
        }
    }
}
