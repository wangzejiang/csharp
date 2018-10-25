using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 拆弹专家
{
    public class ConstClass : Form
    {
        protected const uint LVM_FIRST = 0x1000;
        protected const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        protected const uint LVM_GETHEADER = LVM_FIRST + 31;
        protected const uint LVM_GETITEMTEXT = LVM_FIRST + 45;//获取列表内的内容
        protected const uint LVM_GETITEMW = LVM_FIRST + 75;

        protected const uint LVM_GETSUBITEMRECT = (LVM_FIRST + 56);
        protected const uint LVM_GETITEMSTATE = (LVM_FIRST + 44);
        protected const uint LVM_GETITEMTEXTW = (LVM_FIRST + 115);

        protected const uint HDM_GETITEMCOUNT = 0x1200;
        protected const uint PROCESS_VM_OPERATION = 0x0008;//允许函数VirtualProtectEx使用此句柄修改进程的虚拟内存
        protected const uint PROCESS_VM_READ = 0x0010;//允许函数访问权限
        protected const uint PROCESS_VM_WRITE = 0x0020;//允许函数写入权限
        protected const uint PROCESS_ALL_ACCESS = PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE;
        protected const uint MEM_COMMIT = 0x1000;//为特定的页面区域分配内存中或磁盘的页面文件中的物理存储
        protected const uint MEM_RELEASE = 0x8000;
        protected const uint MEM_RESERVE = 0x2000;//保留进程的虚拟地址空间,而不分配任何物理存储
        protected const uint PAGE_READWRITE = 4;
        protected const uint LVIF_TEXT = 0x0001;

        protected void getRowsCols(IntPtr hwd, out int rows, out int cols)
        {
            IntPtr headerhwnd = Utils.SendMessage(hwd, LVM_GETHEADER, 0, 0);
            rows = ListView_GetItemRows(hwd);
            cols = ListView_GetItemCols(headerhwnd);
        }
        protected int ListView_GetItemCols(IntPtr handle)
        {
            return Utils.SendMessage(handle, HDM_GETITEMCOUNT, 0, 0).ToInt32();
        }

        protected int ListView_GetItemRows(IntPtr handle)
        {
            return Utils.SendMessage(handle, LVM_GETITEMCOUNT, 0, 0).ToInt32();
        }

        protected IntPtr find(IntPtr mainhwd, string rule)
        {
            StringBuilder sb = new StringBuilder(256);
            IntPtr hwd = mainhwd;
            string[] keys = rule.Split('.');
            foreach (string key in keys)
            {
                IntPtr tmp = IntPtr.Zero;
                hwd = Utils.GetWindow(hwd, (int)WindowSearch.GW_CHILD); // 1
                string[] args = key.Split(':');
                int num = args.Length > 1 ? int.Parse(args[1]) : 1;
                int i = 0;
                do
                {
                    Utils.GetClassNameW(hwd, sb, sb.Capacity);
                    if (args[0].Equals(sb.ToString()))
                    {
                        i++;
                        if (i >= num)
                        {
                            break;  // 找到
                        }
                    }
                    hwd = Utils.GetWindow(hwd, (int)WindowSearch.GW_HWNDNEXT);
                } while (hwd != IntPtr.Zero);
                //Console.WriteLine("{0}:{1}",key,hwd);
                if (hwd == IntPtr.Zero)
                {
                    break;
                }
            }
            int d = (int)hwd;
            if (d != 0)
            {
                Utils.GetClassNameW(hwd, sb, sb.Capacity);
                Console.WriteLine("{0}，16进制：{1}，10进制：{2}", sb.ToString(), Convert.ToString(d, 16), d);
            }
            return hwd;
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

    }
}
