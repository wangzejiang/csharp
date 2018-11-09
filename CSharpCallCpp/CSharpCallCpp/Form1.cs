using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCallCpp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport(@"D:\Users\zejiang\Documents\GitHub\csharp\CSharpCallCpp\Debug\DLLTest.dll", EntryPoint = "Test1")]
        extern static int Test1();

        [DllImport(@"D:\Users\zejiang\Documents\GitHub\csharp\CSharpCallCpp\Debug\DLLTest.dll", EntryPoint = "Test2", CallingConvention = CallingConvention.Cdecl)]
        extern static int Test2(int a, int b);

        [DllImport(@"D:\Users\zejiang\Documents\GitHub\csharp\CSharpCallCpp\Debug\DLLTest.dll", CharSet = CharSet.Auto, EntryPoint = "Test3", CallingConvention = CallingConvention.Cdecl)]
        public unsafe extern static sbyte* Test3(sbyte* a, sbyte* b);
        

        private unsafe void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Test1());
            Console.WriteLine(Test2(11, 22));
            sbyte* _ch1 = (sbyte*)(IntPtr)Marshal.StringToHGlobalAnsi("a+++");
            sbyte* _ch2 = (sbyte*)(IntPtr)Marshal.StringToHGlobalAnsi("b+++");
            sbyte*  rs = Test3(_ch1, _ch2);
            string msg = new string(rs);
            Console.WriteLine(msg);
        }

    }
}
